
using System;

namespace slang.Compiler.Coco.Parsing {



public class Parser {
	public const int _EOF = 0;
	public const int _ident = 1;
	public const int _type = 2;
	public const int _number = 3;
	public const int maxT = 8;

	const bool _T = true;
	const bool _x = false;
	const int minErrDist = 2;
	
	public Scanner scanner;
	public Errors  errors;

	public Token t;    // last recognized token
	public Token la;   // lookahead token
	int errDist = minErrDist;

public slang.Compiler.Core.Parsing.Ast.Module Module { get; set; }



	public Parser(Scanner scanner) {
		this.scanner = scanner;
		errors = new Errors();
	}

	void SynErr (int n) {
		if (errDist >= minErrDist) errors.SynErr(la.line, la.col, n);
		errDist = 0;
	}

	public void SemErr (string msg) {
		if (errDist >= minErrDist) errors.SemErr(t.line, t.col, msg);
		errDist = 0;
	}
	
	void Get () {
		for (;;) {
			t = la;
			la = scanner.Scan();
			if (la.kind <= maxT) { ++errDist; break; }

			la = t;
		}
	}
	
	void Expect (int n) {
		if (la.kind==n) Get(); else { SynErr(n); }
	}
	
	bool StartOf (int s) {
		return set[s, la.kind];
	}
	
	void ExpectWeak (int n, int follow) {
		if (la.kind == n) Get();
		else {
			SynErr(n);
			while (!StartOf(follow)) Get();
		}
	}


	bool WeakSeparator(int n, int syFol, int repFol) {
		int kind = la.kind;
		if (kind == n) {Get(); return true;}
		else if (StartOf(repFol)) {return false;}
		else {
			SynErr(n);
			while (!(set[syFol, kind] || set[repFol, kind] || set[0, kind])) {
				Get();
				kind = la.kind;
			}
			return StartOf(syFol);
		}
	}

	
	void Slang() {
		slang.Compiler.Core.Parsing.Ast.ModuleDeclaration m;                                                     
		var bindings = new System.Collections.Generic.List<slang.Compiler.Core.Parsing.Ast.Binding>(); 
		ModuleDeclaration(out m);
		while (la.kind == 5) {
			slang.Compiler.Core.Parsing.Ast.Binding b;                                                               
			Binding(out b);
			bindings.Add(b);                                                                                         
		}
		Module = new slang.Compiler.Core.Parsing.Ast.Module(m, bindings);                                        
	}

	void ModuleDeclaration(out slang.Compiler.Core.Parsing.Ast.ModuleDeclaration m) {
		Expect(4);
		Expect(2);
		m = new slang.Compiler.Core.Parsing.Ast.ModuleDeclaration(t.val);                                        
	}

	void Binding(out slang.Compiler.Core.Parsing.Ast.Binding b) {
		slang.Compiler.Core.Parsing.Ast.BindingDeclaration d = null;                                             
		var parameters = new System.Collections.Generic.List<slang.Compiler.Core.Parsing.Ast.TypeDeclaration>(); 
		slang.Compiler.Core.Parsing.Ast.Expression body;                                                         
		Expect(5);
		Expect(1);
		string name = t.val;                                                                                     
		if (la.kind == 1 || la.kind == 2 || la.kind == 6) {
			if (la.kind == 6) {
				slang.Compiler.Core.Parsing.Ast.TypeDeclaration r;                                                       
				Get();
				TypeDeclaration(out r);
				parameters.Add(r);                                                                                       
			} else {
				slang.Compiler.Core.Parsing.Ast.TypeDeclaration f;                                                       
				TypeDeclaration(out f);
				parameters.Add(f);                                                                                       
				while (la.kind == 6) {
					slang.Compiler.Core.Parsing.Ast.TypeDeclaration p;                                                       
					Get();
					TypeDeclaration(out p);
					parameters.Add(p);                                                                                       
				}
			}
		}
		slang.Compiler.Core.Parsing.Ast.TypeDeclaration returnType = System.Linq.Enumerable.LastOrDefault(parameters); 
		d = new slang.Compiler.Core.Parsing.Ast.FunctionDeclaration(name, parameters, returnType);               
		Expect(7);
		Expression(out body);
		b = new slang.Compiler.Core.Parsing.Ast.Binding(d, body);                                                
	}

	void TypeDeclaration(out slang.Compiler.Core.Parsing.Ast.TypeDeclaration td) {
		if (la.kind == 2) {
			Get();
		} else if (la.kind == 1) {
			Get();
		} else SynErr(9);
		td = new slang.Compiler.Core.Parsing.Ast.TypeDeclaration(t.val);                                         
	}

	void Expression(out slang.Compiler.Core.Parsing.Ast.Expression e) {
		Expect(3);
		e = new slang.Compiler.Core.Parsing.Ast.Expression();                                                    
	}



	public void Parse() {
		la = new Token();
		la.val = "";		
		Get();
		Slang();
		Expect(0);

	}
	
	static readonly bool[,] set = {
		{_T,_x,_x,_x, _x,_x,_x,_x, _x,_x}

	};
} // end Parser


public class Errors {
	public int count = 0;                                    // number of errors detected
	public System.IO.TextWriter errorStream = Console.Out;   // error messages go to this stream
	public string errMsgFormat = "-- line {0} col {1}: {2}"; // 0=line, 1=column, 2=text

	public virtual void SynErr (int line, int col, int n) {
		string s;
		switch (n) {
			case 0: s = "EOF expected"; break;
			case 1: s = "ident expected"; break;
			case 2: s = "type expected"; break;
			case 3: s = "number expected"; break;
			case 4: s = "\"module\" expected"; break;
			case 5: s = "\"let\" expected"; break;
			case 6: s = "\"->\" expected"; break;
			case 7: s = "\"=\" expected"; break;
			case 8: s = "??? expected"; break;
			case 9: s = "invalid TypeDeclaration"; break;

			default: s = "error " + n; break;
		}
		errorStream.WriteLine(errMsgFormat, line, col, s);
		count++;
	}

	public virtual void SemErr (int line, int col, string s) {
		errorStream.WriteLine(errMsgFormat, line, col, s);
		count++;
	}
	
	public virtual void SemErr (string s) {
		errorStream.WriteLine(s);
		count++;
	}
	
	public virtual void Warning (int line, int col, string s) {
		errorStream.WriteLine(errMsgFormat, line, col, s);
	}
	
	public virtual void Warning(string s) {
		errorStream.WriteLine(s);
	}
} // Errors


public class FatalError: Exception {
	public FatalError(string m): base(m) {}
}
}