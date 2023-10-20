using ComputerMethodsOfFinancialMath.LIB.Entities;
using ComputerMethodsOfFinancialMath.LIB.Entities.Options;
using ComputerMethodsOfFinancialMath.LIB.Entities.OptionSolutions;

var S = 100d;
var K = 100d;
var T = 1;
var r = 0.05f;
var sigma = 0.2;
uint iterations = 10_000;

var blackScholes = new BlackScholesSolution(sigma, new Value().ChangeMoneySum(K).ChangeRate(r), new Option(S, K, T));
var monteCarlo = new MonteCarloMethod(sigma, new Value().ChangeMoneySum(K).ChangeRate(r), new Option(S, K, T), iterations);

var bsCall = blackScholes.Call();
var mcCall = monteCarlo.Call();

Console.WriteLine($"Black-Scholes call = {bsCall};\n" +
                  $"Monte Carlo call = {mcCall};\n" +
                  $"Difference={Math.Abs(bsCall - mcCall)}\n" +
                  $"Coefficient={Math.Max(bsCall, mcCall) / Math.Min(bsCall, mcCall)}");

Console.WriteLine(new string('=', 25));

var bsPut = blackScholes.Put();
var mcPut = monteCarlo.Put();

Console.WriteLine($"Black-Scholes put = {bsPut};\n" +
                  $"Monte Carlo put = {mcPut};\n" +
                  $"Difference={Math.Abs(bsPut - mcPut)}\n" +
                  $"Coefficient={Math.Max(bsPut, mcPut) / Math.Min(bsPut, mcPut)}");

Console.WriteLine(new string('=', 25));

Console.WriteLine($"Call coefficient = {Math.Max(bsCall, mcCall) / Math.Min(bsCall, mcCall)}\n" +
    $"Put coefficient = {Math.Max(bsPut, mcPut) / Math.Min(bsPut, mcPut)}\n");
