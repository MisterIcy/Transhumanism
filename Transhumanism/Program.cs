// See https://aka.ms/new-console-template for more information

using Transhumanism.Engine.Logger;

Logger l = new Logger();
l.StartSection("Test");
l.Fatal("Fatal", Category.Application);
l.Error("Fatal", Category.Application);
l.Warning("Fatal", Category.Application);
l.Info("Fatal", Category.Application);
l.Debug("Fatal", Category.Application);
l.Trace("Fatal", Category.Application);
l.EndSection();
l.Flush();

Console.WriteLine("Transhumanism");