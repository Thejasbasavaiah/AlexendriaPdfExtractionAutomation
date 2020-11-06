namespace AlexendriaPdfExtractionAutomation
{
    internal class StatusEventArgs
    {
       
            public string StatusMsg { get; set; }

            public StatusEventArgs(string msg)
            {
                StatusMsg = msg;
            }
        
    }

}