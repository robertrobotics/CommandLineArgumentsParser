using CommandLineArgumentsParser.Interfaces;

namespace CommandLineArgumentsParser.Models
{
    /// <summary>
    /// Class providing basic information about read command line argument [e.g. -nameOfArgument valueOfArgument].
    /// </summary>
    public class Argument : IArgument
    {
        /// <summary>
        /// Name of typed argument.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value of typed argument.
        /// </summary>
        public string Value { get; set; }
    }
}
