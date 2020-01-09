﻿using System;
using System.Collections.Generic;
using AutoStep.Tests.Utils;
using FluentAssertions;
using Xunit;

namespace AutoStep.Tests.Projects
{
    public partial class ProjectFileContentSourceTests
    {
        [Fact]
        public void ConstructorNullFileProviderThrowsException()
        {
            Action act = () => new ProjectFileContentSource("/path", null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetLastContentModifyTimeReturnsUtcDateTime()
        {
            var fileProvider = new DummyFileProvider("content", DateTime.Now);

            var contentSource = new ProjectFileContentSource("/path", fileProvider);

            contentSource.GetLastContentModifyTime().Kind.Should().Be(DateTimeKind.Utc);
        }

        [Fact]
        public void GetContentAsyncGetsContent()
        {
            var fileProvider = new DummyFileProvider("content", DateTime.Now);

            var contentSource = new ProjectFileContentSource("/path", fileProvider);

            contentSource.GetContentAsync().GetAwaiter().GetResult().Should().Be("content");
        }
    }
}
