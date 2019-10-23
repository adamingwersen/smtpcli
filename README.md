# A simple SMTP-client and logfile parser

This is a quick solution for parsing python log-files and sending a report table to a specified email account.

## Running the client

Hopefully the executable file is shipped with this solution, but just in case i made a runner script, [run.sh](https://gitlab.com/adamiw/SMTPClient/blob/master/SMTPClient/SMTPClient/run.sh)

Ideally, all you need to modify is this script. From here, you can specifiy:
1. The reciever of the email. 
2. Where your email [secret](https://gitlab.com/adamiw/simpleEncryption) is generated. 
3. Where your python-generated log-file is located.

Simply modify in the specified order. 

```shell
cd SMTPClient
xbuild /p:Configuration=Release SMTPClient.sln &&
    mono Application/bin/Debug/Application.exe {1} {2} {3}
```

If you do not provide 3 arguments to the executable, it will stop the execution and prompt the user with a guideline of how to use the solution.

When [run.sh](https://gitlab.com/adamiw/SMTPClient/blob/master/SMTPClient/SMTPClient/run.sh) is configured, simply make it executable and run it!:

```shell
./run.sh
```

This client is not intended for spamming colleagues ;-)






