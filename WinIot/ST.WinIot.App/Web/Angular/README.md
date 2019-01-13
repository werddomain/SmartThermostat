# ST.Web.Angular

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 7.1.4.

This project is to show UI to be able to manage devices ans scenes.

Authentication come from Web.OAuth
Data comme from Web.API

## Required Extensions
|Name| Why |
|--|--|
|[Typewriter](http://frhagn.github.io/Typewriter/)  | All model and Api calls are auto-generated when modified |
|[NpmTaskRunner](https://github.com/madskristensen/NpmTaskRunner) | This alow us to build Angular before building the .net core project|



## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

Run `ng build` then `ng build --aot` if you have problem when using Visual Studio Start debug

The Angular code will be in the wwwroot/ng to keep the asp .net core fonctionality. Home/Index action redirect to the angular folder

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
