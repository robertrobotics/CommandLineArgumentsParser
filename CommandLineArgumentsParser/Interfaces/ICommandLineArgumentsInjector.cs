using System.Collections.Generic;

namespace CommandLineArgumentsParser.Interfaces
{
    /// <summary>
    /// Interface providing injection of basic information read from command line arguments of the application.
    /// </summary>
    public interface ICommandLineArgumentsInjector
    {
        /// <summary>
        /// Number of correctly typed command line arguments.
        /// </summary>
        int NumberOfArguments { get; set; }

        /// <summary>
        /// Read arguments from command line.
        /// </summary>
        IEnumerable<IArgument> Arguments { get; set; }
    }
}
