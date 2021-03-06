﻿// -----------------------------------------------------------------------
// <copyright file="ExternalSamplingSpecs.cs" company="Petabridge, LLC">
//      Copyright (C) 2015 - 2018 Petabridge, LLC <https://petabridge.com>
// </copyright>
// -----------------------------------------------------------------------

using FluentAssertions;
using Petabridge.Tracing.Zipkin.Sampling;
using Petabridge.Tracing.Zipkin.Tracers;
using Xunit;

namespace Petabridge.Tracing.Zipkin.Tests.Sampling
{
    public class ExternalSamplingSpecs
    {
        public ExternalSamplingSpecs()
        {
            Tracer = new MockZipkinTracer(sampler: ExternalSampling.Instance);
        }

        protected readonly MockZipkinTracer Tracer;

        [Fact(DisplayName = "Sampling should be enabled by default")]
        public void SpansShouldHaveSamplingSetToEnabledByDefault()
        {
            var span = Tracer.BuildSpan("foo").Start();
            span.Finish();

            span.Sampled.Should().BeTrue();
        }
    }
}