﻿using AutoStep.Elements.Test;

namespace AutoStep.Tests.Builders
{
    public class BackgroundBuilder : BaseBuilder<BackgroundElement>, IStepCollectionBuilder<BackgroundElement>
    {
        public BackgroundBuilder(int line, int column) :
            base(new BackgroundElement
        {
            SourceLine = line,
            StartColumn = column
        })
        {
        }
    }
}
