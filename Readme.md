[![Build Status](https://travis-ci.org/aoisupersix/Bve5_Parsing.svg?branch=master)](https://travis-ci.org/aoisupersix/Bve5_Parsing)
[![MIT License](http://img.shields.io/badge/license-MIT-blue.svg?style=flat)](https://github.com/aoisupersix/Bve5_Parsing/blob/master/License.md)

Bve5_Parsing
===

![bve5PasingImage](images/bve5Parsing.png)

Bve5構文のパーサライブラリです。
Bve5の構文はどのように処理されているのか？という疑問を解消すべく、構文解析用ライブラリIronyを利用し、Bve5.7構文の構文解析器を実装してみました。現在、Bve5.7.6224.40815の一部構文に対応していますが、動作はかなり不安定です。

成果物であるクラスライブラリはGithubのリリースからダウンロードするか、ソースをコンパイルして入手してください。



## Supported Syntaxes
- **Scenario File**
    - Bve5.7全構文に対応
    - namespace: **ScenarioGrammar**
    - 出力: **Dictionary\<string, string\>**
    Keyにステートメント名(Route,Vehicleなど)、Valueにステートメントの値が格納された辞書型で出力されます。

- **Map File**
    - 古い構文(ex.Legacyなど)や数学関数を除くBve5.7全構文に対応
    - namespace: **MapGrammar**
    - 出力: **MapDataクラス**
    MapDataクラスは以下のフィールドで構成されています。
      - **Version**: バージョン情報
      - **Encoding**: ファイルエンコーディング
      - **StructureListPath**, **StationListPath**, **SignalListPath**, **SoundListPath**, **Sound3DListPath**: 各リストファイルのファイルパス
      - **Statements**: 各構文情報をまとめたSyntaxDataクラスのリスト

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
    string input;
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
