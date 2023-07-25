static void Menu(){

Console.Clear();

Console.WriteLine("O que deseja fazer ?");
Console.WriteLine("1 - Abrir Arquivo");
Console.WriteLine("2 - Criar Novo Arquivo");
Console.WriteLine("0 - Sair");

short option = short.Parse(Console.ReadLine());

if(option == 1){
    Abrir();
}else if(option == 2){
    Editar();
}else if(option == 0){
    System.Environment.Exit(0);
}else{
    Menu();
}

}
Menu();

static void Abrir(){
    Console.Clear();

    Console.WriteLine("Qaul o caminho do arquivo ?");
    string path = Console.ReadLine();

    using(var file = new StreamReader(path)){
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }

    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

static void Editar(){

    Console.Clear();

    Console.WriteLine("Digite seu Texto Abaixo:  | (ESC para sair)");
    Console.WriteLine("------------------------");

    string texto = "";

    // Do While | Enquanto ele não apertar a tecla ESC ele vai continuar digitando o codigo
    do{ 
        texto += Console.ReadLine(); // Vai armazenar o texto que o usuario digitar
        texto += Environment.NewLine; // Quebrando a linha em cada leitura
    }
    while(Console.ReadKey().Key != ConsoleKey.Escape); 
    // Enquanto ele as teclas for diferente do ESC, ele não vai sair 


    Salvar(texto);
}

static void Salvar(string text){

    Console.Clear();
    Console.WriteLine("Qual caminho para salvar o arquivo ?");
    var path = Console.ReadLine();

    using( var file = new StreamWriter(path) ){
        file.Write(text);
    } 
    
    Console.WriteLine($"Arquivo {path} salvo com sucesso");
    Menu();
}