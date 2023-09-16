using Microsoft.SemanticKernel;
var builder = new KernelBuilder();

builder.WithAzureChatCompletionService(
         "gpt-35-turbo",                  // Azure OpenAI Deployment Name
         "https://openai-prem.openai.azure.com/", // Azure OpenAI Endpoint
         "4548d54f5c9641de9e473170d92be4a6");      // Azure OpenAI Key

var kernel = builder.Build();

string translationPrompt = @"{{$input}}

Translate the text to math.";

string summarizePrompt = @"{{$input}}

Give me a TLDR with the fewest words.";

var translator = kernel.CreateSemanticFunction(translationPrompt);
var summarize = kernel.CreateSemanticFunction(summarizePrompt);

string inputText = @"
1st Law of Thermodynamics - Energy cannot be created or destroyed.
2nd Law of Thermodynamics - For a spontaneous process, the entropy of the universe increases.
3rd Law of Thermodynamics - A perfect crystal at zero Kelvin has zero entropy.";

// Run two prompts in sequence (prompt chaining)
var output = await kernel.RunAsync(inputText, translator, summarize);

Console.WriteLine(output);

// Output: ΔE = 0, ΔSuniv > 0, S = 0 at 0K.