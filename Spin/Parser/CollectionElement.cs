﻿using Spin.Builder;
using System.Collections.Generic;
using System.Text;

namespace Spin.Parser
{
    public class CollectionElement : IExpressionElement
    {
        public IEnumerable<IExpressionElement> SubElements { get; set; }

        public CollectionElement(IEnumerable<IExpressionElement> subElements)
        {
            SubElements = subElements;
        }

        public void Execute(Sequence sequence, LineBuilder builder)
        {
            if (SubElements != null)
            {
                foreach (var element in SubElements)
                {
                    element.Execute(sequence, builder);
                }
            }
        }
        
        public override string ToString()
        {
            if (SubElements == null)
                return string.Empty;

            var builder = new StringBuilder();
            foreach (var element in SubElements)
            {
                builder.Append(element.ToString());
            }

            return builder.ToString();
        }
    }
}
