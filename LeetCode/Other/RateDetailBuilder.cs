using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCode.Other
{
    public class HreXmlAttributes : Dictionary<string, string> { } // make casting (implicit operator) work


    public class RateDetailBuilder
    {
        // private readonly Dictionary<string, string> _attributes;
        private readonly HreXmlAttributes _attributes;

        public RateDetailBuilder()
        {
            //_attributes = new Dictionary<string, string>();
            _attributes = new HreXmlAttributes();
        }

        public RateDetailBuilder WithType(string value)
        {
            _attributes.Add("rateDetailType", value);
            return this;
        }

        public RateDetailBuilder WithCategory(string value)
        {
            _attributes.Add("category", value);
            return this;
        }

        public RateDetailBuilder WithStringValue(string value)
        {
            // TODO
            _attributes.Add("stringValue", value);
            return this;
        }

        public RateDetailBuilder WithIntValue(string value)
        {
            // TODO
            return this;
        }

        public RateDetailBuilder WithBoolValue(string value)
        {
            // TODO
            return this;
        }

        // type convert
        public static implicit operator HreXmlAttributes(RateDetailBuilder builder)
        {
            return builder._attributes;
        }
    }

    public class RateDetailBuilderUsage
    {
        RateDetailBuilder attributes => new RateDetailBuilder();

        [Test]
        public void Usage()
        {
            attributes.WithType("Type").WithCategory("NA").WithStringValue("example");
            CreateRateDetail(attributes.WithType("Type").WithCategory("NA").WithStringValue("example"));
        }

        public void CreateRateDetail(Dictionary<string, string> attributes)
        {
            foreach (var attr in attributes)
            {
                Console.WriteLine($"{attr.Key} : {attr.Value}");
            }
        }
    }
}
