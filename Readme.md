[![Build Status](https://travis-ci.org/aoisupersix/Bve5_Parsing.svg?branch=master)](https://travis-ci.org/aoisupersix/Bve5_Parsing)
[![MIT License](http://img.shields.io/badge/license-MIT-blue.svg?style=flat)](https://github.com/aoisupersix/Bve5_Parsing/blob/master/License.md)

Bve5_Parsing
===

![bve5PasingImage](images/bve5Parsing.png)

Bve5の構文はどのように処理されているのか？という疑問を解消すべく、構文解析用ライブラリIronyを利用し、Bve5.7構文の構文解析器を実装してみました。現在、Bve5.7.6224.40815の一部構文に対応していますが、動作はかなり不安定です。

## Supported Syntaxes
- **Scenario File**
    - Bve5.7全構文に対応
    - namespace: ScenarioGrammar
    - 解析結果の型: Dictionary\<string, string\>  
    Keyにステートメント名(一つ目の文字のみ大文字)、Valueにステートメントの値が格納されてます。

- **Map File**
    - include構文や古い構文(ex.Legacyなど)を除くBve5.7全構文に対応
    - namespace: MapGrammar
    - 解析結果の型: MapDataクラス  
    詳しくは、![MapData.cs](https://github.com/aoisupersix/Bve5_Parsing/blob/master/Bve5_Parsing/MapGrammar/MapData.cs)を参照してください

その他は今後作っていきます👍

## Requirement
Importing your projects, **Irony 0.9.1** & **Irony.Interpreter 0.9.1** from  
+ [nuget Irony](https://www.nuget.org/packages/Irony/) & [nuget Irony.Interpreter](https://www.nuget.org/packages/Irony.Interpreter/)
+ [Irony - .NET Language Implementation Kit.](https://irony.codeplex.com/)  

and this library from ![Bve5_Parsing](https://github.com/aoisupersix/Bve5_Parsing/releases/download/v0.1.6527.27089/Bve5_Parsing.dll).

## Usage for C\# ##

ex. C#でMapFileの構文解析を行う場合.  

```csharp
using Irony.Interpreter;
using Irony.Parsing;
using Bve5_Parsing.MapGrammar;

...

    ScriptApp app = new ScriptApp(new LanguageData(new MapGrammar.MapGrammar()));
    try
    {
        MapData result = (MapData)app.Evaluate(input); //result data

        // Process result
    }
    catch(ScriptException e)
    {
        //Exception handling
    }

...
```

構文が正しく解析された場合、結果は**MapDataクラス**で返ってきます。**MapDataクラス**の詳細は![MapData.cs](https://github.com/aoisupersix/Bve5_Parsing/blob/master/Bve5_Parsing/MapGrammar/MapData.cs)を参照してください。例えば、ファイルヘッダのバージョン情報は**MapData.Version**に格納されています。

## UsedLibrarys

Bve5_Parsing is using the following library.

#### [Irony - .NET Language Implementation Kit.](https://irony.codeplex.com/)
> The MIT License (MIT)
>
> Copyright (c) 2011 Roman Ivantsov

* **ライセンス全文 :** [licenses\Irony.txt](https://github.com/aoisupersix/Bve5_Parsing/blob/master/licenses/Irony.txt)

## License
The MIT License (MIT)

Copyright(c) 2017 Aoi Tanaka

**[License.md](https://github.com/aoisupersix/Bve5_Parsing/blob/master/License.md)**
