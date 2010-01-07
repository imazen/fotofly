// <copyright file="FotoFlyMetadata.cs" company="Taasss">Copyright (c) 2009 All Right Reserved</copyright>
// <author>Ben Vincent</author>
// <date>2009-12-06</date>
// <summary>FotoFlyMetadata</summary>
namespace FotoFly
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class FotoFlyMetadata : IFotoFlyMetadata
    {
        public FotoFlyMetadata()
        {
        }

        [XmlAttribute]
        public DateTime UtcDate { get; set; }

        [XmlElement]
        public double? UtcOffset { get; set; }

        public bool IsUtcOffsetSet
        {
            get
            {
                return this.UtcOffset != null;
            }
        }

        [XmlAttribute]
        public DateTime LastEditDate { get; set; }

        [XmlAttribute]
        public DateTime AddressOfGpsLookupDate { get; set; }

        [XmlAttribute]
        public DateTime OriginalCameraDate { get; set; }

        [XmlAttribute]
        public string OriginalCameraFilename { get; set; }

        public Address AddressOfGps { get; set; }

        public Address Address { get; set; }

        [XmlAttribute]
        public string AddressOfGpsSource { get; set; }

        [XmlAttribute]
        public GpsPosition.Accuracies AccuracyOfGps { get; set; }

        public bool IsUtcOffsetCorrect(DateTime dateTaken)
        {
            if (this.UtcOffset == null || this.UtcDate == null)
            {
                return false;
            }
            else
            {
                double utcOffsetInMins = this.UtcOffset.Value * 60;
                double dateGapInMins = new TimeSpan(dateTaken.Ticks - this.UtcDate.Ticks).TotalMinutes;

                return utcOffsetInMins == dateGapInMins;
            }
        }
    }
}