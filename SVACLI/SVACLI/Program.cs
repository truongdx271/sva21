using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using AntlrTestCsharp.Config;
using AntlrTestCsharp.Object;
using AntlrTestCsharp.parser;
using AntlrTestCsharp.Tracer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using AntlrTestCsharp.Model;

namespace AntlrTestCsharp
{
    class Program
    {

        static void Main(string[] args)
        {
            string code = "";
            string name = "";
            string po = "";
            string member = "";
            int ticket = 0;
            //C:\Users\dbui\Desktop\FashionShop2.0\FashionShop2.0.sln
            //string solutionPath = @"E:\Project\FashionShop2.0\FashionShop2.0.sln";
            if ((args.Length == 0)||(args[0] == "-h"))
            {
                printHelp();
            }
            else { 
                if ((Array.IndexOf(args,"-g")!=-1)&&(args.Length == 1))
                {
                    Console.WriteLine(retrieveData());
                }
                else if (args.Length == 12)
                {
                    //Full Command: SVACLI.exe -u PATH -c CODE -n NAME -p PO -m MEMBER -t TICKET
                    projObject finalObject= setParam(args[3], args[5], args[7], args[9], Convert.ToInt32(args[11]), args[1]);
                    sendObject(finalObject);
                    printJsonObject(finalObject);
                }
                else if ((Array.IndexOf(args, "-u") != -1) && (args.Length == 2))
                {
                    //string a = @"C:\Users\dbui\Desktop\SVA2.0\SVACLI\SVACLI\FashionShop2.0";
                    //printSimplifiedResult(scanASP(args[1]));
                    //printJsonObject(setParam(code, name, po, member, ticket, args[1]));
                    //printSimplifiedResult(finalObject.scans[0].resultItems);
                    //sendObject(setParam(code, name, po, member, ticket, args[1]));
                    //printSimplifiedResult(finalObject.scans[0].resultItems);
                    Console.ReadLine();
                }
                else
                {
                    printHelp();
                }
            }
        }

        //Module quet tong hop .NET
        private static List<ResultItem> scanASP(string solutionPath)
        {
            //string solutionPath = args[1];
            //string solutionPath = @"C:\Users\Administrator\Desktop\AntlrTestCsharp\AntlrTestCsharp\SVACLI\FashionShop2.0\FashionShop2.0.sln";
            //string solutionPath = @"C:\Users\dbui\Desktop\FashionShop2.0\FashionShop2.0.sln";
            //string solutionPath = @"C:\Users\dbui\Desktop\vtracking_web\App_Code";
            //List<string> listTmpProject = loadSolution(solutionPath);
            List<string> listProject = new List<string>();
            //foreach (var item in listTmpProject)
            //{
            //   if (!item.Contains(":"))
            //    {
            //        string tmp = solutionPath.Substring(0, solutionPath.LastIndexOf('\\') + 1) + item;
            //        listProject.Add(tmp);
            //    }
            //    else
            //    {
            //        listProject.Add(item);
            //    }
            //}
            listProject.Add(solutionPath);


            //progress toan bo project
            //foreach (var project in listProject)
            //{
            //    Progress(project);
            //}


            //test module hoa

            List<string> listCs = new List<string>();
            List<string> listAscx = new List<string>();
            List<string> listAspx = new List<string>();
            List<string> listConfig = new List<string>();

            foreach (var item in listProject)
            {
                string[] fileAscx = Directory.GetFiles(item, "*.ascx", SearchOption.AllDirectories);
                string[] fileAspx = Directory.GetFiles(item, "*.aspx", SearchOption.AllDirectories);
                string[] fileCs = Directory.GetFiles(item, "*.cs", SearchOption.AllDirectories);
                string[] fileConfig = Directory.GetFiles(item, "Web.config", SearchOption.AllDirectories);

                //khoi tao danh sach file cs
                if (listCs == null || listCs.Count < 1)
                {
                    listCs = new List<string>();
                }
                foreach (var file in fileCs)
                {
                    listCs.Add(file);
                }

                //khoi tao danh sach file ascx
                if (listAscx == null || listAscx.Count < 1)
                {
                    listAscx = new List<string>();
                }
                foreach (var file in fileAscx)
                {
                    listAscx.Add(file);
                }

                //Khoi tao danh sach file aspx
                if (listAspx == null || listAspx.Count < 1)
                {
                    listAspx = new List<string>();
                }
                foreach (var file in fileAspx)
                {
                    listAspx.Add(file);
                }
                //Khoi tao danh sach file config
                if (listConfig == null || listConfig.Count < 1)
                {
                    listConfig = new List<string>();
                }
                foreach (var file in fileConfig)
                {
                    listConfig.Add(file);
                }
            }
            List<ItemObject> finalResult = new List<ItemObject>();

            //Scan SQL
            foreach (var item in listCs)
            {
                finalResult = scanSQL(item, finalResult);
            }
            //Scan XXE
            foreach (var item in listCs)
            {
                finalResult = scanXXE(item, finalResult);
            }
            //Scan ghi log nhay cam
            foreach (var item in listCs)
            {
                finalResult = scanLogging(item, finalResult);
            }
            //Scan ma hoa yeu
            foreach (var item in listCs)
            {
                finalResult = scanBadCrypt(item, finalResult);
            }
            //Scan file upload
            foreach (var item in listCs)
            {
                finalResult = scanFileUpload(item, finalResult);
            }
            //Scan XSS
            foreach (var item in listAspx)
            {
                finalResult = scanXSS(item, finalResult);
            }
            foreach (var item in listAscx)
            {
                finalResult = scanXSS(item, finalResult);
            }
            //Scan file Config
            foreach (var item in listConfig)
            {
                finalResult = scanDebug(item, finalResult);
            }
            List<ResultItem> simplifiedResult = new List<ResultItem>();
            simplifiedResult = convertObject(finalResult);
            if (finalResult != null)
            {
                //Console.WriteLine("ok");
                //printResult(finalResult);
                //exportTxt(finalResult);
                return simplifiedResult;
            }
            //Console.WriteLine(retrieveData());
            return simplifiedResult;
        }

        //Module quet SQL
        private static List<ItemObject> scanSQL(string fileName, List<ItemObject> listResult)
        {
            if (listResult == null || listResult.Count == 0)
            {
                listResult = new List<ItemObject>();
            }

            string code = readFile2(fileName);

            CSharpLexer lexer = new CSharpLexer(new AntlrInputStream(code));
            lexer.RemoveErrorListeners();
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CSharpParser parser = new CSharpParser(tokens);

            IParseTree tree = parser.compilation_unit();
            ParseTreeWalker walker = new ParseTreeWalker();
            ExtractClassParser listener = new ExtractClassParser(parser);
            //FindGlobalVariable listener = new FindGlobalVariable(parser);

            walker.Walk(listener, tree);
            //}
            //Main tracer

            //sql
            if (listener.listMethodContext != null)
            {
                //Console.WriteLine(filename);
                List<MethodContext> listMethod = listener.getListMethod();
                foreach (var method in listMethod)
                {
                    ParseTreeWalker methodWalker = new ParseTreeWalker();
                    FindQueryInMethod queryListener = new FindQueryInMethod(parser, method.lineList);
                    methodWalker.Walk(queryListener, method.context);
                    FindLineOfExpression lineListener = new FindLineOfExpression(parser, method.context, queryListener.listExpressLine, queryListener.commandVar, queryListener.queryVar);
                    methodWalker.Walk(lineListener, method.context);
                    method.lineList = lineListener.listExpressLine;
                    FindUsedMethodInClass methodListener = new FindUsedMethodInClass(parser, method);
                    methodWalker.Walk(methodListener, method.context);
                    if (methodListener.listResult != null)
                    {
                        foreach (var item in methodListener.listResult)
                        {
                            ItemObject obj = new ItemObject(item.BaselineItem, item.methodName, item.listExp, fileName, item.startLine, "FAIL");
                            listResult.Add(obj);
                        }
                    }
                }
            }
            return listResult;
        }

        //Module quet XXE
        private static List<ItemObject> scanXXE(string fileName, List<ItemObject> listResult)
        {
            if (listResult == null || listResult.Count == 0)
            {
                listResult = new List<ItemObject>();
            }

            string code = readFile2(fileName);

            CSharpLexer lexer = new CSharpLexer(new AntlrInputStream(code));
            lexer.RemoveErrorListeners();
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CSharpParser parser = new CSharpParser(tokens);

            IParseTree tree = parser.compilation_unit();
            ParseTreeWalker walker = new ParseTreeWalker();
            ExtractClassParser listener = new ExtractClassParser(parser);
            //FindGlobalVariable listener = new FindGlobalVariable(parser);

            walker.Walk(listener, tree);

            if (listener.listXMLContext != null)
            {
                List<ParserRuleContext> listMethod = listener.listXMLContext;
                foreach (var method in listMethod)
                {
                    ParseTreeWalker methodWalker = new ParseTreeWalker();
                    FindXXEInMethod methodListener = new FindXXEInMethod(parser);
                    methodWalker.Walk(methodListener, method);
                    if (methodListener.isVuln)
                    {
                        ItemObject obj = new ItemObject(methodListener.tmpMethod.BaselineItem, methodListener.tmpMethod.methodName, null, fileName, methodListener.tmpMethod.startLine, "FAIL");
                        listResult.Add(obj);
                    }
                }
            }

            return listResult;
        }

        //Module quet Ma hoa yeu
        private static List<ItemObject> scanBadCrypt(string fileName, List<ItemObject> listResult)
        {
            if (listResult == null || listResult.Count == 0)
            {
                listResult = new List<ItemObject>();
            }

            string code = readFile2(fileName);

            CSharpLexer lexer = new CSharpLexer(new AntlrInputStream(code));
            lexer.RemoveErrorListeners();
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CSharpParser parser = new CSharpParser(tokens);

            IParseTree tree = parser.compilation_unit();
            ParseTreeWalker walker = new ParseTreeWalker();
            ExtractClassParser listener = new ExtractClassParser(parser);
            //FindGlobalVariable listener = new FindGlobalVariable(parser);

            walker.Walk(listener, tree);

            if (listener.listBadCryptContext != null)
            {
                List<ParserRuleContext> listMethod = listener.listBadCryptContext;
                foreach (var method in listMethod)
                {
                    ParseTreeWalker methodWalker = new ParseTreeWalker();
                    FindBadCrypt methodListener = new FindBadCrypt(parser);
                    methodWalker.Walk(methodListener, method);
                    ItemObject obj = new ItemObject(methodListener.tmpMethod.BaselineItem, methodListener.tmpMethod.methodName, null, fileName, methodListener.tmpMethod.startLine, "FAIL");
                    listResult.Add(obj);
                }
            }

            return listResult;
        }

        //Module quet FileUpload
        private static List<ItemObject> scanFileUpload(string fileName, List<ItemObject> listResult)
        {
            if (listResult == null || listResult.Count == 0)
            {
                listResult = new List<ItemObject>();
            }
            string code = readFile2(fileName);

            CSharpLexer lexer = new CSharpLexer(new AntlrInputStream(code));
            lexer.RemoveErrorListeners();
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CSharpParser parser = new CSharpParser(tokens);

            IParseTree tree = parser.compilation_unit();
            ParseTreeWalker walker = new ParseTreeWalker();
            FindUploadInMethod uploadListener = new FindUploadInMethod(parser);
            walker.Walk(uploadListener, tree);
            if (uploadListener.listMethod != null)
            {
                foreach (var item in uploadListener.listMethod)
                {
                    ItemObject obj = new ItemObject(item.BaselineItem, item.methodName, null, fileName, item.startLine, "WARNING");
                    listResult.Add(obj);
                }
            }

            return listResult;
        }

        //Module quet XSS
        private static List<ItemObject> scanXSS(string fileName, List<ItemObject> listResult)
        {
            if (listResult == null || listResult.Count == 0)
            {
                listResult = new List<ItemObject>();
            }

            string code = readFile2(fileName);

            TraceForXss tracer = new TraceForXss(code, fileName);
            if (tracer.listItem != null)
            {
                foreach (var item in tracer.listItem)
                {
                    listResult.Add(item);
                }
            }
            return listResult;
        }

        //Module quet LOG
        private static List<ItemObject> scanLogging(string fileName, List<ItemObject> listResult)
        {
            if (listResult == null || listResult.Count == 0)
            {
                listResult = new List<ItemObject>();
            }
            string code = readFile2(fileName);

            CSharpLexer lexer = new CSharpLexer(new AntlrInputStream(code));
            lexer.RemoveErrorListeners();
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            CSharpParser parser = new CSharpParser(tokens);

            IParseTree tree = parser.compilation_unit();
            ParseTreeWalker walker = new ParseTreeWalker();
            FindLoggingInMethod uploadListener = new FindLoggingInMethod(parser);
            walker.Walk(uploadListener, tree);
            if (uploadListener.listMethod != null)
            {
                foreach (var item in uploadListener.listMethod)
                {
                    ItemObject obj = new ItemObject(item.BaselineItem, item.methodName, null, fileName, item.startLine, "FAIL");
                    listResult.Add(obj);
                }
            }
            return listResult;
        }

        //Module quet che do debug
        private static List<ItemObject> scanDebug(string fileName, List<ItemObject> listResult)
        {
            if (listResult == null || listResult.Count == 0)
            {
                listResult = new List<ItemObject>();
            }

            string code = readFile2(fileName);

            TraceForMisconfig tracer = new TraceForMisconfig(code, fileName);
            if (tracer.listItem != null)
            {
                foreach (var item in tracer.listItem)
                {
                    listResult.Add(item);
                }
            }
            return listResult;
        }

        //Module ho tro
        private static projObject setParam(string code, string name, string po, string member, int ticket, string path) 
        {
            projObject finalObject = new projObject();
            List<Scan> scanList = new List<Scan>();
            Scan scanDetail = new Scan();
            scanDetail.resultItems = scanASP(path);
            scanDetail.scantime = DateTime.Now;
            scanDetail.No = 1;
            scanDetail.total = scanDetail.resultItems.Count;
            scanList.Add(scanDetail);

            List<String> lmember = new List<string>();
            List<int> lticket = new List<int>();
            lmember.Add(member);
            lticket.Add(ticket);
            finalObject.scans = scanList;
            finalObject.projectCode = code;
            finalObject.projectMember = lmember;
            finalObject.projectName = name;
            finalObject.projectOwner = po;
            finalObject.ticket = lticket;

            return finalObject;
        }
        private static int checkParam()
        {
            return 1;
        }
        private static void printHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("[+] -h :: Help");
            Console.WriteLine("[+] -g :: Get data from DB");
            Console.WriteLine("[+] -u PATH :: Scan project at folder PATH and send to DB");
        }
        private static String retrieveData()
        {
            string url = @"http://10.60.156.82:8080/api/resultItems";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }
        private static List<ResultItem> convertObject(List<ItemObject> listResult)
        {
            List<ResultItem> simplifiedResult = new List<ResultItem>();
            foreach (var item in listResult)
            {
                ResultItem sobj = new ResultItem(item.identify, item.displayTxt, item.pathFile, item.lineNumber, item.result);
                simplifiedResult.Add(sobj);
            }
            return simplifiedResult;
        }
        private static void printJsonObject(projObject objectResult)
        {
            string jsonContent = JsonConvert.SerializeObject(objectResult, Formatting.Indented);
            Console.WriteLine(jsonContent);
        }
        private static void sendObject(projObject objectResult)
        {
            string url = @"http://10.60.156.82:8080/api/projObjects";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            string jsonContent = JsonConvert.SerializeObject(objectResult, Formatting.Indented);
            //j = "{"item.identify + "|" + item.displayTxt + "|" + item.pathFile + "|" + item.lineNumber + "|" + item.result;
            //lines[i] = j;
            //Console.WriteLine(jsonContent);
            
            Byte[] byteArray = encoding.GetBytes(jsonContent);
            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            long length = 0;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;
                }
            }
            catch (WebException ex)
            {
                // Log exception and throw as for GET example above
            }

            byteArray = null;
            //Console.WriteLine(item.identify + "|" + item.displayTxt + "|" + item.pathFile + "|" + item.lineNumber + "|" + item.result);
            
        }
        private static void sendData(List<ItemObject> listResult)
        {
            string url = @"http://10.60.156.82:8080/api/resultItems";
            string[] lines = new string[listResult.Count];
            int i = 0;
            string j = "";
            foreach (var item in listResult)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                string jsonContent = JsonConvert.SerializeObject(item, Formatting.Indented);
                //j = "{"item.identify + "|" + item.displayTxt + "|" + item.pathFile + "|" + item.lineNumber + "|" + item.result;
                //lines[i] = j;
                i = i + 1;
                Console.WriteLine(jsonContent);
                Byte[] byteArray = encoding.GetBytes(jsonContent);
                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/json";

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                long length = 0;
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        length = response.ContentLength;
                    }
                }
                catch (WebException ex)
                {
                    // Log exception and throw as for GET example above
                }

                byteArray = null;
                //Console.WriteLine(item.identify + "|" + item.displayTxt + "|" + item.pathFile + "|" + item.lineNumber + "|" + item.result);
            }
        }
        private static void exportTxt(List<ItemObject> listResult)
        {
            string[] lines = new string[listResult.Count];
            int i = 0;
            string j = "";
            foreach (var item in listResult)
            {
                j = item.identify + "|" + item.displayTxt + "|" + item.pathFile + "|" + item.lineNumber + "|" + item.result;
                lines[i] = j;
                i = i + 1;
                //Console.WriteLine(item.identify + "|" + item.displayTxt + "|" + item.pathFile + "|" + item.lineNumber + "|" + item.result);
            }
            System.IO.File.WriteAllLines(@"C:\Users\dbui\Desktop\SVACLI\result.txt", lines);
            Console.WriteLine("Total vuln: " + listResult.Count);
        }
        private static void printResult(List<ItemObject> listResult)
        {
            foreach (var item in listResult)
            {
                Console.WriteLine(item.identify + " | " + item.displayTxt + " | " + item.pathFile + " | " + item.lineNumber + " | " + item.result);
                if (item.listExp != null)
                {
                    foreach (var point in item.listExp)
                    {
                        Console.WriteLine(" + " + point.value + " | " + point.line);
                    }
                }
            }

            Console.WriteLine("Total vuln: " + listResult.Count);
        }
        private static void printSimplifiedResult(List<ResultItem> simplifiedResult)
        {
            foreach (var item in simplifiedResult)
            {
                Console.WriteLine(item.identify + " | " + item.displayTxt + " | " + item.pathFile + " | " + item.lineNumber + " | " + item.result);
            }

            Console.WriteLine("Total vuln: " + simplifiedResult.Count);
        }
        private static void print(List<MethodInfor> listResult)
        {
            if (listResult != null)
            {
                foreach (var item in listResult)
                {
                    Console.WriteLine(item.className + "|" + item.methodName + "|" + item.startLine);
                    foreach (var point in item.listExp)
                    {
                        Console.WriteLine(" + " + point.line + " | " + point.value);
                    }

                }
            }
            else
            {
                return;
            }
        }
        private static string readFile(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string line in File.ReadLines(filePath))
            {
                sb.Append(line);
            }
            return sb.ToString();
        }
        private static string readFile2(string filePath)
        {
            byte[] encoded = File.ReadAllBytes(filePath);
            string result = System.Text.Encoding.UTF8.GetString(encoded);
            return result;
        }
        private static List<string> loadSolution(string pathFile)
        {
            if (pathFile == null)
            {
                return null;
            }

            using (StreamReader sr = new StreamReader(pathFile))
            {
                List<string> listProject = new List<string>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (String.IsNullOrEmpty(line) || !line.StartsWith("Project("))
                    {
                        continue;
                    }
                    string[] tmpProjectArr = line.Split(',');
                    if (tmpProjectArr.Length == 3)
                    {
                        string tmpProject = tmpProjectArr[1];
                        tmpProject = tmpProject.Substring(tmpProject.IndexOf('"') + 1, tmpProject.LastIndexOf('\\') - tmpProject.IndexOf('"') - 1);
                        listProject.Add(tmpProject);
                    }
                }
                return listProject;
            }
        }
    }
}
