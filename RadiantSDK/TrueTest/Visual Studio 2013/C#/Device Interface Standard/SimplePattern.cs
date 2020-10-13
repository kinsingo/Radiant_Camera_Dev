using System;
using TrueTestPatternGenerator;
using System.Xml.Serialization;

namespace StandardDI
{
    [Serializable()]
    public class SimplePattern : PatternBase
    {
        [XmlIgnore()]
        protected override string Name
        {
            get
            {
                return "Numeric Image #" + ImageNumber.ToString();
            }
        }
        
        public int ImageNumber { get; set; }

        SimplePattern()
        {
            ImageNumber = 1;
        }
    }
}
