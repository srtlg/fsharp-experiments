open Terminal.Gui.Elmish


type Model = 
    {
        Count : int
        Text : string
    }


type Msg = 
    | Inc
    | Dec
    | ChangeText of string


let init () =
    {
        Count = 1
        Text = "Hallo!"
    },
    Cmd.none


let update (msg: Msg) (model: Model) = 
    match msg with
    | Inc -> { model with Count = model.Count + 1 }, Cmd.none
    | Dec -> { model with Count = model.Count - 1 }, Cmd.none
    | ChangeText s -> { model with Text = s }, Cmd.none


let view (state: Model) (dispatch: Msg -> unit) = 
    View.window [
        window.title "Hallo Titel!"
        prop.children [
            View.button [
                prop.position.x.at 2
                prop.position.y.at 2
                button.text "inc"
                button.onClick (fun () -> dispatch Inc)
            ]
            View.button [
                prop.position.x.at 2
                prop.position.y.at 4
                button.text "dec"
                button.onClick (fun () -> dispatch Dec)
            ]
            View.label [
                prop.position.x.at 2
                prop.position.y.at 6
                label.text $"Value: {state.Count}"   
            ]
        ]
    ]


[<EntryPoint>]
let main argv =
    Program.mkProgram init update view
    |> Program.run
    0

