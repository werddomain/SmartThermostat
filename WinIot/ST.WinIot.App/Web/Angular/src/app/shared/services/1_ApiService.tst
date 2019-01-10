${
    // Base Informations : http://lightswitchhelpwebsite.com/Blog/tabid/61/EntryId/4313/Turbocharging-Your-Angular-4-Development-Using-Typewriter.aspx
    using Typewriter.Extensions.WebApi;
    Template(Settings settings)
    {
        
        settings.IncludeProject("ST.Web.API");
        settings.OutputFilenameFactory = file => 
        {
            var FinalFileName = file.Name.Replace("Controller", "");
            FinalFileName = FinalFileName.Replace(".cs", "");
            return $"{FinalFileName}.service.ts";
        };
    }
    // Change ApiController to Service
    string ServiceName(Class c) => c.Name.Replace("Controller", "Service");
    // Turn IActionResult into void

    string RemoveActionResult(string type){
    if(type.StartsWith("ActionResult"))
        {
                if(type.StartsWith("ActionResult<"))
                {

                  var t = type.Replace("ActionResult<", "");
                  t = t.Remove(t.Length - 1);//Remove the last char
                  return t;
                }
                else
                return "void";
        } 
        else
        {
            if (type.StartsWith("IActionResult")){
                if(type.StartsWith("IActionResult<"))
                {

                  var t = type.Replace("IActionResult<", "");
                  t = t.Remove(t.Length - 1);//Remove the last char
                  return t;
                }
                else
                return "void";
            }
            else
                return type;
        }
    }
    string ReturnType(Method objMethod) 
    {
       return RemoveActionResult(objMethod.Type.Name);
    }

    string EnsureTypeName(string type){
     switch (type)
        {
            case null: 
            case "":
            return "";

            default: return type.First().ToString().ToUpper() + type.Substring(1);
        }
    }
    bool isImported(List<String> imported, string type){
        
        var t = type.Replace("[]", "").ToLower();
        if (t == "void")
            return true;
        if (imported.Any(o=> o == t))
           return true;

        imported.Add(t);
        return false;

       
    }
    // Get the non primitive paramaters so we can create the Imports at the
    // top of the service
    string ImportsList(Class objClass)
    {
        var ImportsOutput = "";
        // Get the methods in the Class
        var objMethods = objClass.Methods;
        // Loop through the Methdos in the Class
        var imports = new List<string>();
        var imported = new List<string>();
        var debug = "";
        foreach(Method objMethod in objMethods)
        {
            if (objMethod.Type.IsPrimitive == false){
                    ImportsOutput = RemoveActionResult(objMethod.Type.Name).Replace("[]", "");
                    if (ImportsOutput != null && ImportsOutput != "") 
                        if (!isImported(imported, ImportsOutput)) {
                            imports.Add($"import {{ { EnsureTypeName(ImportsOutput) } }} from '../classes/{ImportsOutput}';");
                            imported.Add(ImportsOutput);
                            }
                 }
            // Loop through each Parameter in each method
            foreach(Parameter objParameter in objMethod.Parameters)
            {
                //var debugPrimitive = objParameter.Type.IsPrimitive ? "Primitive": "NonPrimitive";
                //debug += $"{objParameter.Type.Name}({debugPrimitive}), ";
                
                // If the Paramater is not prmitive we need to add this to the Imports
                if(!objParameter.Type.IsPrimitive){
                    ImportsOutput = objParameter.Name.Replace("[]", "");
                    if (ImportsOutput != null && ImportsOutput != "") 
                    if (!isImported(imported, ImportsOutput)) {
                        imports.Add($"import {{ { EnsureTypeName(ImportsOutput) } }} from '../classes/{ImportsOutput}';");
                        imported.Add(ImportsOutput);
                        }
                }
                //else imports.Add($"/*{objParameter.Name} IsPrimitive*/");
            }
            //debug += Environment.NewLine;
        }
        if (imports.Count > 0)
        return string.Join(Environment.NewLine, imports) ;
        return ""; //"/*Nothing to import*/" + Environment.NewLine + $"/*{debug}*/";
    }
    // Format the method based on the return type
    string MethodFormat(Method objMethod)
    {
        if(objMethod.HttpMethod() == "get"){
            return  $"<{RemoveActionResult(objMethod.Type.Name)}>(_Url)";
        } 
        
        if(objMethod.HttpMethod() == "post"){
            return  $"<{RemoveActionResult(objMethod.Type.Name)}>(_Url, {objMethod.Parameters[0].name})";
        }
        if(objMethod.HttpMethod() == "put"){
            return  $"<{RemoveActionResult(objMethod.Type.Name)}>(_Url, {objMethod.Parameters[1].name})";
        }
        if(objMethod.HttpMethod() == "delete"){
            return  $"<{RemoveActionResult(objMethod.Type.Name)}>(_Url)";
        }
        
        return  $"";
    }
}
${
// #ApiService
//The do not modify block below is intended for the outputed typescript files... }
//*************************DO NOT MODIFY**************************
//
//THESE FILES ARE AUTOGENERATED WITH TYPEWRITER AND ANY MODIFICATIONS MADE HERE WILL BE LOST
//PLEASE VISIT http://frhagn.github.io/Typewriter/ TO LEARN MORE ABOUT THIS VISUAL STUDIO EXTENSION
//
//*************************DO NOT MODIFY**************************
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'; 
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
//ST.Web.API
$Classes(o=> o.Attributes.Any(i=> i.Name == "GenerateApi") && o.Namespace.StartsWith("ST.Web.API"))[$ImportsList
import { GlobalService } from "../../global.service";
//Remote Call
@Injectable()
export class $ServiceName {
    constructor(private _httpClient: HttpClient, private global: GlobalService) { }        
    $Methods[
    // $HttpMethod: $Url      
    $name($Parameters[$name: $Type][, ]): Observable<$ReturnType> {
        var _Url = this.global.ApiConfig.apiServer + `/$Url`;
            return this._httpClient.$HttpMethod$MethodFormat
                .catch(this.handleError);
    }
    ]
    // Utility
    private handleError(error: HttpErrorResponse) {
        console.error(error);
        let customError: string = "";
        if (error.error) {
            customError = error.status === 400 ? error.error : error.statusText
        }
        return Observable.throw(customError || 'Server error');
    }
}]
