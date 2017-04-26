namespace _02.HornetComm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Text;

    public class HornetComm
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var messageRegex = new Regex(@"^(\d+) <-> ([A-Za-z0-9]+)$");
            var broadcastRegex = new Regex(@"^(\D+) <-> ([A-Za-z0-9]+)$");
            var messageList = new List<StringBuilder>();
            var broadcastList = new List<StringBuilder>();

            while (inputLine != "Hornet is Green")
            {
                var messageMatch = messageRegex.Match(inputLine);
                var broadcastMatch = broadcastRegex.Match(inputLine);

                if (messageMatch.Success)
                {
                    var recepientCode = messageMatch.Groups[1].Value;
                    var message = messageMatch.Groups[2].Value;
                    var currentReversedCode = new StringBuilder();

                    for (int i = recepientCode.Length - 1; i >= 0; i--)
                    {
                        currentReversedCode.Append(recepientCode[i]);
                    }

                    currentReversedCode.Append($" -> {message}");

                    messageList.Add(currentReversedCode);
                }
                else if (broadcastMatch.Success)
                {
                    var message = broadcastMatch.Groups[1].Value;
                    var currentMessage = new StringBuilder();
                    var frequency = broadcastMatch.Groups[2].Value;

                    foreach (var symbol in frequency)
                    {
                        if (char.IsUpper(symbol))
                        {
                            currentMessage.Append(symbol.ToString().ToLower());
                        }
                        else if (char.IsLower(symbol))
                        {
                            currentMessage.Append(symbol.ToString().ToUpper());
                        }
                        else
                        {
                            currentMessage.Append(symbol);
                        }
                    }

                    currentMessage.Append($" -> {message}");

                    broadcastList.Add(currentMessage);
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");

            if (!broadcastList.Any())
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var broadcast in broadcastList)
                {
                    Console.WriteLine(broadcast.ToString());
                }
            }

            Console.WriteLine("Messages:");

            if (!messageList.Any())
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var message in messageList)
                {
                    Console.WriteLine(message.ToString());
                }
            }
        }
    }
}