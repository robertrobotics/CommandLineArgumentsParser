using CommandLineArgumentsParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CommandLineArgumentsParser.Models
{
    /// <summary>
    /// Class providing injection of basic information read from command line arguments of the application.
    /// </summary>
    public class CommandLineArgumentsInjector : ICommandLineArgumentsInjector
    {
        /// <summary>
        /// Number of correctly typed command line arguments.
        /// </summary>
        public int NumberOfArguments { get; set; }

        /// <summary>
        /// Read arguments from command line.
        /// </summary>
        public IEnumerable<IArgument> Arguments { get; set; }

        /// <summary>
        /// Creates an instance of <see cref="CommandLineArgumentsInjector"/>.
        /// </summary>
        public CommandLineArgumentsInjector()
        {
            this.Arguments = this.GetArguments();
            this.NumberOfArguments = this.Arguments.Count();
        }

        protected IEnumerable<IArgument> GetArguments() => 
            this.ParseCommandLineArguments(Environment.GetCommandLineArgs());

        private List<IArgument> ParseCommandLineArguments(string[] arguments)
        {
            var parsedArguments = new List<IArgument>();
            var argumentsFormatRegex = new Regex(@"[-]\w+\s\w+");
            var integratedArguments = string.Join(" ", arguments);
            var groupedArguments = argumentsFormatRegex.Matches(integratedArguments);

            groupedArguments.ToList().ForEach(groupedArgument =>
            {
                var argument = this.GetSingleArgument(groupedArgument);
                parsedArguments.Add(argument);
            });

            return parsedArguments ?? throw new ArgumentNullException(nameof(parsedArguments));
        }

        private Argument GetSingleArgument(Match matchedValue)
        {
            var argument = new Argument();

            argument.Name = Regex.Match(matchedValue.Value, @"[-]\w+").Value.Replace("-", string.Empty).Trim();
            argument.Value = Regex.Match(matchedValue.Value, @"\s+\w+").Value.Trim();

            return argument;
        }
    }
}
