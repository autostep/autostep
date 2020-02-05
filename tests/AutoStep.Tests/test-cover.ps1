
dotnet test /p:CollectCoverage=true /p:CoverletOutput=TestResults/coverage.xml /p:CoverletOutputFormat=opencover /p:ExcludeByAttribute=CompilerGeneratedAttribute /p:Exclude=[*]AutoStep.Language.Test.Parser.*

if($LASTEXITCODE -eq 0)
{
    # Find the first file under the folder.
    #$item = Get-ChildItem TestResults/Coverage/*/*.xml

    #Remove-Item  ./TestResults/Coverage/LastResult.xml -ErrorAction Ignore

    #Move-Item $item TestResults/Coverage/LastResult.xml

    reportgenerator.exe "-reports:TestResults/coverage.xml" "-targetdir:TestResults/CoverageReport"
}