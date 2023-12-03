# Aspire Dashboard を Aspire AppHost 無しで動かす

このソースは Aspire Dashboard を Aspire AppHost プロジェクト以外の任意のプロジェクトで動かすサンプルコードです。

## 動かし方

1. Dashboard プロジェクトを稼働します。
2. http://localhost:5281 をブラウザで開きます。
3. WebAPI プロジェクトを稼働します。

## 説明

### Dashboard

- DashboardはAspire.Dashboardパッケージをインストールしています
- 実装はすべてProgram.csにしています
- DashboardWebApplicationがIDashboardViewModelServiceをImplementしたクラスを必要とするため、AddSingletonで具象クラスを設定しています
- DashboardViewModelServiceは特にロジックはありません

### WebAPI

- Program.csにOpenTelemteryのログとメトリクスの実装をしています
- 環境変数として次の情報をデバッグ実行時に設定しています。WebAPIのデバッグ起動プロファイルを確認してください
  - OTEL_EXPORTER_OTLP_ENDPOINT: http://localhost:18889

## 課題

- Trace が Dashboard に表示されません

# Run Aspire Dashboard without Aspire AppHost

This source code is a sample code to run Aspire Dashboard in any project other than the Aspire AppHost project.

## How to Run

1. Start the Dashboard project.
2. Open http://localhost:5281 in a browser.
3. Start the WebAPI project.

## Description

### Dashboard

- The Dashboard installs the Aspire.Dashboard package.
- All implementations are in Program.cs.
- DashboardWebApplication requires a class that implements IDashboardViewModelService, so I set the concrete class with AddSingleton.
- DashboardViewModelService doesn't have any specific logic.

### WebAPI

- Program.cs implements logging and metrics with OpenTelemetry.
- The following information is set as environment variables during debugging. Please check the WebAPI debug launch profile.
    - OTEL_EXPORTER_OTLP_ENDPOINT: http://localhost:18889

## Issue

- Trace is not displayed in the Dashboard.
