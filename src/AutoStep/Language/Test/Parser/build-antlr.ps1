$ErrorActionPreference = "Stop";
$antlrVersion = "4.8";

if(!(Test-Path "${PSScriptRoot}\antlr-$antlrVersion-complete.jar"))
{
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    Invoke-WebRequest "https://www.antlr.org/download/antlr-$antlrVersion-complete.jar" -OutFile "${PSScriptRoot}\antlr-$antlrVersion-complete.jar"
}

java -jar $PSScriptRoot\antlr-$antlrVersion-complete.jar .\AutoStepLexer.g4 -Dlanguage=CSharp -package AutoStep.Language.Test.Parser
java -jar $PSScriptRoot\antlr-$antlrVersion-complete.jar .\AutoStepParser.g4 -Dlanguage=CSharp -package AutoStep.Language.Test.Parser -visitor

$files = Get-Item "*.cs";

# Convert public antlr components to internal.
foreach($f in $files)
{
    $content = Get-Content $f -Raw;

    $content = $content.Replace('public partial class', 'internal partial class');
    $content = $content.Replace('public interface', 'internal interface');

    $content | Set-Content $f;
}