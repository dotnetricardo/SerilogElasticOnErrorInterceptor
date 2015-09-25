# SerilogElasticOnErrorInterceptor
Interceptor for CodeCop that automatically logs exceptions with Serilog and Elastic on each intercepted method. 

# Instructions
To place this Interceptor on all intercepted methods, just insert "OnErrorInterceptor" in the GlobalInterceptors array of your copconfig.json file, like so:

```
{
    "Types": [
        {
            "TypeName": "ConsoleApplication1.FooClass, ConsoleApplication1",
            "Methods": [
                {
                    "MethodSignature": "FooMethod1(System.Object, System.String)",
                    "Interceptors": [ ]
                },
                {
                    "MethodSignature": "FooMethod2(System.String)",
                    "Interceptors": [ ]
                }
            ],
          "GenericArgumentTypes": [ ]
        }
    ],
    "GlobalInterceptors": ["OnErrorInterceptor"],
    "Key":"Your product key or leave empty for free product mode limited to intercepting 25 methods"

}
```
If you want to use this Interceptor on just some methods, inside the copconfig.json file insert "OnErrorInterceptor" in the Interceptors array of those methods, like so:
```
{
    "Types": [
        {
            "TypeName": "ConsoleApplication1.FooClass, ConsoleApplication1",
            "Methods": [
                {
                    "MethodSignature": "FooMethod1(System.Object, System.String)",
                    "Interceptors": ["OnErrorInterceptor" ]
                },
                {
                    "MethodSignature": "FooMethod2(System.String)",
                    "Interceptors": [ ]
                }
            ],
          "GenericArgumentTypes": [ ]
        }
    ],
    "GlobalInterceptors": [],
    "Key":"Your product key or leave empty for free product mode limited to intercepting 25 methods"

}
```
<b>Configuration</b>

Add your Elastic Node Uri to your appsettings section in web.config:
```
<add key="ElasticNode" value="https://7l3nh4abc:d3xildecas@elasticcluster-24045628.us-west-2.bonsai.io" />

```
<b>Logs Example</b>

This is the log format that this interceptor will output:
```
{"@timestamp":"2015-09-25T15:48:00.8615269+01:00","level":"Error","messageTemplate":"There was an error method .ctor from Tester.Foo type","message":"There was an error method .ctor from Tester.Foo type","exceptions":[{"Depth":0,"ClassName":"System.Reflection.TargetInvocationException","Message":"Ex...

```



# Nuget Package
https://www.nuget.org/packages/Serilog.Elastic.CodeCop/

Make sure you read the CodeCop wiki page at https://bitbucket.org/codecop_team/codecop/wiki/Home to get started using this powerful method interception tool for .NET .
