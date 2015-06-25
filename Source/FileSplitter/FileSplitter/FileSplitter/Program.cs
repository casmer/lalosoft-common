using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileSplitter
{
  class Program
  {

    public const char CarriageReturn = '\r';
    public const char NewLine = '\n';
    
    public static string ReadLine(StreamReader tr, int lineLenMax, ref bool prematureEnd)
    {
      StringBuilder res = new StringBuilder(lineLenMax);
      bool lineEnd = false;
      int chars = 0;
      
      while (!lineEnd && tr.Peek() >= 0)
      {
        char read = Convert.ToChar(tr.Read());

        if (read == CarriageReturn || read == NewLine)
        {
          bool again = true;
          while (again)
          {
            if (tr.Peek() >= 0)
            {
              char nextC = Convert.ToChar(tr.Peek());
              if (nextC == CarriageReturn || nextC == NewLine)
              {
                tr.Read();
                again = true;
              }
              else
              {
                again = false;
              }

            }
            else
            {
              again = false;

            }
          }

          lineEnd = true;
        }
        else
        {
          
          res.Append(read);
          chars++;
          if (chars >=lineLenMax)
          {
            lineEnd = true;
            prematureEnd = true;
            //Console.WriteLine("Prematurelineend");
          }
        }

      }
      if (res.Length > 0 || lineEnd)
        return res.ToString();
      else
        return null;
    }

    static void Main(string[] args)
    {
      try
      {
#if DEBUG
        MakeFile();
#endif
        if (args.Length >=3 && args.Length <= 5)
        {
          int xLines = 0;
          if (!int.TryParse(args[0], out xLines))
          {
            Console.WriteLine("Invalid lines parameter");
            return;
          }
          string filename = args[1];
          if (!File.Exists(filename))
          {
            Console.WriteLine("Invalid filename parameter");
            return;
          }
          string Outpath = args[2];
          string fullpath = Path.Combine(Environment.CurrentDirectory, Outpath);
          if (!Directory.Exists(fullpath))
          {
            Directory.CreateDirectory(fullpath);
          }

          int lineLenmax = 10000;
          if (args.Length == 4)
          {
            //create at most x files
            if (!int.TryParse(args[3], out lineLenmax))
            {
              Console.WriteLine("Invalid max line length parameter");
              return;
            }
          }
          int maxFiles = 0;

          if (args.Length==5)
          {
            //create at most x files
            if (!int.TryParse(args[4], out maxFiles))
            {
              Console.WriteLine("Invalid max files parameter");
              return;
            }
          }
          FileInfo sourceFile = new FileInfo(filename);
          using (StreamReader fs = File.OpenText(filename))
          {
            int counter = 0;
            int fileCount = 1;
            string outfile = Outfile(fileCount, Outpath, sourceFile);
            Console.WriteLine("creating file: {0}", outfile);

            FileStream fw = File.Open(outfile, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fw);
            bool prematureEnd = false;
            string line = ReadLine(fs, lineLenmax, ref prematureEnd);
            
            while (line !=null)
            {
              if (counter >= xLines)
              {
                if (prematureEnd)
                {
                  Console.WriteLine("Hit Premature line ends.");
                }
                prematureEnd = false;
                counter = 0;
                sw.Flush();
                sw.Close();
                fw.Close();
                fileCount++;
                if (maxFiles!=0 && fileCount>maxFiles)
                {
                  Console.WriteLine("Hit max files, exiting.");
                  break;
                }
                outfile = Outfile(fileCount, Outpath, sourceFile);
                Console.WriteLine("creating file: {0}", outfile);
                fw = File.Open(outfile, FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fw);
              }

              sw.WriteLine(line);
              counter++;


              line = ReadLine(fs, lineLenmax, ref prematureEnd);
            }
            try
            {
              sw.Flush();
              sw.Close();
              fw.Close();
            }
            catch (Exception)
            {
              
              
            }
          }
        }
        else
        {
          Console.WriteLine(
@"Usage: fileRenamer [lines] [filename] [outputpath] [optoinal:linemaxlen] [optional:maxfiles]
lines = lines of data from filename to put in each output file
filename = name of file to split
outputpath = path for output, files will be
  [outputpath]\[filename].[filenumber].part
maxfiles = stop after making x files (for testing)
linemaxlen - max length of a line, default 10000
");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error Occurred.");
        Console.WriteLine(ex.ToString());
      }
    }

    private static void MakeFile()
    {
      FileStream tw = File.OpenWrite(@"C:\temp\testfile.txt");
      
      StreamWriter sw = new StreamWriter(tw);
      sw.Write("NormalLineNormalLineNormalLineNormalLineNormalLine");
      for (int i=0; i < 100; i++)
      {
        sw.Write("NormalLine");
        sw.Write(Environment.NewLine);
        if ((i % 10) == 0)
        {
          for (int i2=0; i2<3; i2++)
          {
            sw.Write("CarraigeLine");
            sw.Write(CarriageReturn);    

          }
        }
        if ((i % 5) == 0)
        {
          for (int i2 = 0; i2 < 3; i2++)
          {
            sw.Write("linefeed line");
            sw.Write(NewLine);
          }
        }
      }
      sw.Flush();
      tw.Flush();
      tw.Close();
      
    }

    private static string Outfile(int fileCount, string Outpath, FileInfo sourceFile)
    {
      string outfile = Path.Combine(Outpath, string.Format("{0}.{1}.part", sourceFile.Name, fileCount));
      return outfile;
    }
  }
}
