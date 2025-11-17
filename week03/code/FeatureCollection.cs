// FeatureCollection.cs
namespace SetsAndMapsJson
{
    // JSON mapping classes for earthquakes
    public class FeatureCollection
    {
        public Feature[] Features { get; set; }
    }

    public class Feature
    {
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public double Mag { get; set; }
        public string Place { get; set; }
    }

    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
} // closes namespace
