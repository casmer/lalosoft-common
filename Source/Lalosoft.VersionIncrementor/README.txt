To use:

Add this to the first line after the <Project> tag in the project file:

<UsingTask TaskName="Lalosoft.VersionIncrementor.VersionBuildTask" AssemblyFile="../Lalosoft.VersionIncrementor.dll" />

AssemblyFile should have a relative path from the csproj to the location of the build dll.



Add this to the Targets section at the end of the project file:


 <Target Name="BeforeBuild">
    <VersionBuildTask VersionBaseFile="$(MSBuildProjectDirectory)\..\Version.xml" AssemblyFileLocation="$(MSBuildProjectDirectory)\Properties\AssemblyInfo.cs" ConfigurationName="$(ConfigurationName)">
    </VersionBuildTask>
  </Target>
  
  
  