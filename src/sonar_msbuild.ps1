SonarScanner.MSBuild.exe begin /k:"DA_RedisInfo" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="c76f9b240fd8ca4b0b8e2c960c5d4e547b4800b0"
MsBuild.exe DA.RedisInfo.sln /t:Rebuild
SonarScanner.MSBuild.exe end /d:sonar.login="c76f9b240fd8ca4b0b8e2c960c5d4e547b4800b0"