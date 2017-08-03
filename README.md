# posted [![Build status](https://ci.appveyor.com/api/projects/status/cxaro110l6a3a49k?svg=true)](https://ci.appveyor.com/project/yohanmishkin/posted)
Object oriented email for .Net

# Email templates
- Tokens
	- @Model
	- @Subject

* Can't chain methods on tokens, but can chain properties
* Can't reference null properties on email model

To configure Smtp host you'd like to use, simply add an entry to your config file like this:

```xml
<configuration>
  <system.net>
    <mailSettings>
      <smtp>
        <network 
          host="localhost"
          port="25" />
      </smtp>
    </mailSettings>
  </system.net>
</configuration>
```