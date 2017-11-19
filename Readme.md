[![Build Status](https://travis-ci.org/aoisupersix/Bve5_Parsing.svg?branch=master)](https://travis-ci.org/aoisupersix/Bve5_Parsing)
[![MIT License](http://img.shields.io/badge/license-MIT-blue.svg?style=flat)](/License.md)

Bve5_Parsing
===

![bve5PasingImage](images/bve5Parsing.png)

Bve5構文のパーサライブラリです。
Bve5の構文はどのように処理されているのか？という疑問を解消すべく、構文解析用ライブラリIronyを利用し、Bve5.7構文の構文解析器を実装してみました。現在、Bve5.7.6224.40815の一部構文に対応していますが、動作はかなり不安定です。

成果物であるクラスライブラリはGithubのリリースからダウンロードするか、ソースをコンパイルして入手してください。



## Supported Syntaxes
- #### Scenario File
    - Bve5.7全構文に対応
    - namespace: **ScenarioGrammar**
    - 出力: **ScenarioDataクラス**
    構文解析の結果は、ScenarioDataクラスで返します。ScenarioDataクラスは以下のフィールドで構成されています。
      - **string Version**: シナリオファイルのバージョン情報
      - **List\<FilePath\> Route**: マップファイルの相対パス
      - **List\<FilePath\> Vehicle**: 車両ファイルの相対パス
      - **string Image**: サムネイル画像の相対パス
      - **string Title**: シナリオタイトル
      - **string RouteTitle**: 路線名
      - **string VehicleTitle**: 車両名
      - **string Author**: 路線と車両の作者
      - **string Comment**: シナリオの説明

    なお、RouteとVechicleに関しては、複数ファイルの指定と重み係数に対応するため、相対パスと重み係数をまとめたFilePath構造体のリストを返します。相対パスは**FilePath.Value**、重み係数は**FilePath.Weight**に対応しています。

    詳しくは、[ScenarioData.cs](/Bve5_Parsing/ScenarioGrammar/ScenarioData.cs)を参照してください。

- #### Map File
    - 古い構文(ex.Legacyなど)や数学関数を除くBve5.7全構文と変数に対応
    - namespace: **MapGrammar**
    - 出力: **MapDataクラス**
    構文解析の結果は、MapDataクラスで返します。MapDataクラスは以下のフィールドで構成されています。

      - **string Version**: バージョン情報
      - **string Encoding**: ファイルエンコーディング
      - **string StructureListPath**: ストラクチャリストの相対パス
      - **string StationListPath**: 停車場リストの相対パス
      - **string SignalListPath**: 信号リストの相対パス
      - **string SoundListPath**: サウンドリストの相対パス
      - **string Sound3DListPath**: 固定音源リストの相対パス
      - **List\<SyntaxData\> Statements**: 各構文情報をまとめたSyntaxDataクラスのリスト

    - そのうち、Statementsは各構文情報をまとめたSyntaxDataクラスのリストを返します。SyntaxDataクラスは以下のフィールドで構成されてます。

      - **double Distance**: 構文の距離程
      - **string[] MapElement**: 構文のマップ要素(ex.Structure,Repeaterなど)
      - **string Key**: 構文のキー(Track['この部分'])
      - **string Function**: 構文の関数名(ex.Interpolate)
      - **Dictionary\<string, object\> Arguments**: 構文の引数名。引数がキーであれば型はstring、引数が数値であれば型はdoubleで返します。

    詳しくは、[MapData.cs](/Bve5_Parsing/MapGrammar/MapData.cs)や、[MapElementNodes.cs](/Bve5_Parsing/MapGrammar/AstNodes/MapElementNodes.cs)を参照してください

その他は今後作っていきます👍

## Requirement
Importing your projects, **Irony 0.9.1** & **Irony.Interpreter 0.9.1** from  
+ [nuget Irony](https://www.nuget.org/packages/Irony/) & [nuget Irony.Interpreter](https://www.nuget.org/packages/Irony.Interpreter/)
+ [Irony - .NET Language Implementation Kit.](https://irony.codeplex.com/)  

and this library from [Bve5_Parsing](https://github.com/aoisupersix/Bve5_Parsing/releases/download/v0.1.6527.27089/Bve5_Parsing.dll).

## Usage for C\# ##

ex. C#でMapFileの構文解析を行う場合.  

```csharp
using Irony.Interpreter;
using Irony.Parsing;
using Bve5_Parsing.MapGrammar;

...
    string input; //String to be analyzed
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

構文が正しく解析された場合、結果は**MapDataクラス**で返ってきます。例えば、ファイルヘッダのバージョン情報は**MapData.Version**に格納されています。

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
