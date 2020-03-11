﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace AutoStep.Benchmarks
{
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(DefaultConfig.Instance);

            ArtifactsPath = Path.Combine(AppContext.BaseDirectory, "artifacts", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"));

            Add(MemoryDiagnoser.Default);
        }
    }
}
