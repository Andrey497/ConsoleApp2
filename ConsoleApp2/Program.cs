using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Logics;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {

        static readonly string Token = "1601042076:AAFNepz16GfYMc0sTRD2-xdPuI6igzV59hU";
        static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient(Token);
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }
        
        
        
        
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            try
            {
                if ((e.Message.Text != null) && (e.Message.Text != "Hi, Bot!"))
                {
                    await botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat,
                      text: "You said:\n" + e.Message.Text
                    );
                    //}
                    var Message = new Message(e.Message.Text.ToLower());
                    
                    if (Message.KeyWords == "Place")
                    {
                        if (Message.ParametersReturn.Length == 0)
                        {
                            await botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: "Простити,но я не знаю где это находится"
                        );
                        }
                        var msg = await botClient.SendVenueAsync(
                                 chatId: e.Message.Chat.Id,
                                latitude: float.Parse(Message.ParametersReturn[1], CultureInfo.InvariantCulture),
                                longitude: float.Parse(Message.ParametersReturn[2], CultureInfo.InvariantCulture),
                                title: Message.ParametersReturn[0],
                                address: Message.ParametersReturn[3]
                            );

                    }
                    else
                        
                    
                    if (Message.KeyWords == "Person")
                    {
                        var msg = await botClient.SendContactAsync(
                                        chatId: e.Message.Chat.Id,
                                        phoneNumber: Message.ParametersReturn[3],
                                        firstName: Message.ParametersReturn[0]+ Message.ParametersReturn[1],
                                        lastName: Message.ParametersReturn[2],
                                        vCard: "BEGIN:VCARD\n" +
                                                "VERSION:3.0\n" +
                                                "N:Solo;Han\n" +
                                                "ORG:Scruffy-looking nerf herder\n" +
                                                $"TEL;TYPE=voice,work,pref:{Message.ParametersReturn[3]}\n" +
                                                $"EMAIL:{Message.ParametersReturn[4]}\n" +
                                                "END:VCARD"
                                        );
                    }
                }
            }
            catch
            {
                await botClient.SendTextMessageAsync(
                            chatId: e.Message.Chat,
                            text: "Я вас не понял,можите задать вопрос по другому,я всеголишь бот"
                        );
            }


            }
        }
    }

