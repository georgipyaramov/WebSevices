﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ILetterService")]
public interface ILetterService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILetterService/GetOccurences", ReplyAction="http://tempuri.org/ILetterService/GetOccurencesResponse")]
    int GetOccurences(string firstLetter, string secondLetter);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILetterService/GetOccurences", ReplyAction="http://tempuri.org/ILetterService/GetOccurencesResponse")]
    System.Threading.Tasks.Task<int> GetOccurencesAsync(string firstLetter, string secondLetter);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ILetterServiceChannel : ILetterService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class LetterServiceClient : System.ServiceModel.ClientBase<ILetterService>, ILetterService
{
    
    public LetterServiceClient()
    {
    }
    
    public LetterServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public LetterServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LetterServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public LetterServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int GetOccurences(string firstLetter, string secondLetter)
    {
        return base.Channel.GetOccurences(firstLetter, secondLetter);
    }
    
    public System.Threading.Tasks.Task<int> GetOccurencesAsync(string firstLetter, string secondLetter)
    {
        return base.Channel.GetOccurencesAsync(firstLetter, secondLetter);
    }
}
