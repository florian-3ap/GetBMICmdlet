using System;
using System.Management.Automation;

/*
 * Import-Module /Users/floriannapflin/Workspace/HF/GetBMICmdlet/GetBMICmdlet/GetBMICmdlet/bin/Debug/net5.0/GetBMICmdlet.dll
 * 
 * Get-BMI -Height 1.95 -Weight 90
 * Get-BMI -Height 1.95 -Weight 90 -Debug
 * Get-BMI -Height 195 -Weight 90 -Debug
 * 
 * @{ Height = 1.95; Weight = 90 } | Get-BMI -Height { $_.Height } -Weight { $_.Weight }
 * @{ Height = 1.95; Weight = 90 } | Get-BMI -Height { $_.Height } -Weight { $_.Weight }
 * @(@{ Height = 1.95; Weight = 90 }, @{ Height = 1.80; Weight = 80 }) | Get-BMI -Height { $_.Height } -Weight { $_.Weight }
 */

namespace GetBMICmdlet
{
    [Cmdlet(VerbsCommon.Get, "BMI")]
    [OutputType(typeof(double))]
    public class GetBMICmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public double Height { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public double Weight { get; set; }

        protected override void BeginProcessing()
        {
            WriteDebug("Cmdlet processing is beginning");
        }

        protected override void ProcessRecord()
        {
            if ((Height - Math.Round(Height) == 0))
            {
                WriteDebug($"Convert Height into Meter");
                Height /= 100.0;
            }

            WriteDebug($"Calculating BMI with Height = {Height.ToString()} and Weight = {Weight.ToString()}");

            var result = Math.Round(Weight / (Height * Height));

            WriteObject(result);
        }

        protected override void EndProcessing()
        {
            WriteDebug("Cmdlet processing is finished");
        }
    }
}