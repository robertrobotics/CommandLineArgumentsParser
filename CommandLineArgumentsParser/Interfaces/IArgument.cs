namespace CommandLineArgumentsParser.Interfaces
{
    /// <summary>
    /// Interface providing basic information about read command line argument [e.g. -nameOfArgument valueOfArgument].
    /// </summary>
    public interface IArgument
    {
        /// <summary>
        /// Name of typed argument.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Value of typed argument.
        /// </summary>
        string Value { get; set; }
    }
}
