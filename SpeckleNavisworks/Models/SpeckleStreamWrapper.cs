using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Speckle.Core.Api;
using SpeckleCore;

namespace SpeckleNavisworks.Models
{
    public class SpeckleStreamWrapper
    {
        public enum SelectionType
        {
            None, ActiveSelection, SelectionSet
        }

        public Stream SpeckleStream { get; private set; }
        public SelectionType ModelSelectionType { get; private set; }
        public string FileName { get; private set; }
        public string DocumentGUID { get; private set; }
        public string SelectedSelectionSet { get; set; }

        public SpeckleStreamWrapper(Stream speckleStream)
        {
            SpeckleStream = speckleStream;
            ModelSelectionType = SelectionType.None;
            FileName = System.IO.Path.GetFileName(NavisworksWrapper.Document.FileName);
            DocumentGUID = NavisworksWrapper.DocumentGUID;
            SelectedSelectionSet = "";
        }
    }
}