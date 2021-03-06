using System;
using System.Collections.Generic;

namespace PolyPerfect.Crafting.Framework
{
    /// <summary>
    ///     Compares items at equivalent positions within their respective collections
    /// </summary>
    public class MatchingPositionSatisfier<T> : MatchingPositionSatisfier<T, T, Quantity>, ISatisfier<IEnumerable<T>, Quantity>
    {
        public MatchingPositionSatisfier(ISatisfier<T, T, Quantity> elementSatisfier, Quantity maxValue) : base(elementSatisfier, maxValue)
        {
        }
    }

    /// <summary>
    ///     Compares items at equivalent positions within their respective collections
    /// </summary>
    public class MatchingPositionSatisfier<REQUIREMENT, SUPPLIED, OUTPUT> : ISatisfier<IEnumerable<REQUIREMENT>, IEnumerable<SUPPLIED>, OUTPUT>
        where OUTPUT : IComparable<OUTPUT>
    {
        readonly ISatisfier<REQUIREMENT, SUPPLIED, OUTPUT> _elementSatisfier;
        readonly OUTPUT _maxValue;

        public MatchingPositionSatisfier(ISatisfier<REQUIREMENT, SUPPLIED, OUTPUT> elementSatisfier, OUTPUT maxValue)
        {
            _elementSatisfier = elementSatisfier;
            _maxValue = maxValue;
        }

        public OUTPUT SatisfactionWith(IEnumerable<REQUIREMENT> required, IEnumerable<SUPPLIED> supplied)
        {
            var output = _maxValue;
            using (var requires = required.GetEnumerator())
            {
                using (var supplies = supplied.GetEnumerator())
                {
                    while (requires.MoveNext() && supplies.MoveNext())
                    {
                        var req = requires.Current;
                        var sup = supplies.Current;
                        var satisfaction = _elementSatisfier.SatisfactionWith(req, sup);
                        if (satisfaction.CompareTo(output) < 0)
                        {
                            output = satisfaction;
                            if (output.Equals(default(OUTPUT)))
                                return output;
                        }
                    }
                }
            }

            return output;
        }
    }
}