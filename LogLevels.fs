module LogLevels

open System.Text.RegularExpressions

let private MessageRegex = Regex "\[(?<logLevel>\w+)\]:\s*(?<message>.+)$"
let private parse (logLine: string) =
    let groups = (MessageRegex.Match logLine).Groups
    (groups.["message"].Value, groups.["logLevel"].Value.ToLower())
let message (logLine: string): string = logLine |> parse |> fst
let logLevel(logLine: string): string = logLine |> parse |> snd
let reformat(logLine: string): string =
    let message, logLevel = parse logLine
    $"{message} ({logLevel})"
