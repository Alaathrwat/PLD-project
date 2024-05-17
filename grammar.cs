
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF            =  0, // (EOF)
        SYMBOL_ERROR          =  1, // (Error)
        SYMBOL_WHITESPACE     =  2, // Whitespace
        SYMBOL_MINUS          =  3, // '-'
        SYMBOL_MINUSMINUS     =  4, // '--'
        SYMBOL_EXCLAMEQ       =  5, // '!='
        SYMBOL_PERCENT        =  6, // '%'
        SYMBOL_LPAREN         =  7, // '('
        SYMBOL_RPAREN         =  8, // ')'
        SYMBOL_TIMES          =  9, // '*'
        SYMBOL_COMMA          = 10, // ','
        SYMBOL_DIV            = 11, // '/'
        SYMBOL_COLON          = 12, // ':'
        SYMBOL_COLONCOLON     = 13, // '::'
        SYMBOL_SEMI           = 14, // ';'
        SYMBOL_PLUS           = 15, // '+'
        SYMBOL_PLUSPLUS       = 16, // '++'
        SYMBOL_LT             = 17, // '<'
        SYMBOL_LTEQ           = 18, // '<='
        SYMBOL_EQ             = 19, // '='
        SYMBOL_EQEQ           = 20, // '=='
        SYMBOL_GT             = 21, // '>'
        SYMBOL_GTEQ           = 22, // '>='
        SYMBOL_CHAR           = 23, // char
        SYMBOL_CLASS          = 24, // Class
        SYMBOL_ELSE           = 25, // else
        SYMBOL_END            = 26, // End
        SYMBOL_FLOAT          = 27, // Float
        SYMBOL_FROM           = 28, // from
        SYMBOL_FUNCTION       = 29, // function
        SYMBOL_IDENTIFIER     = 30, // Identifier
        SYMBOL_IF             = 31, // if
        SYMBOL_INT            = 32, // int
        SYMBOL_NUM            = 33, // Num
        SYMBOL_PRIVATE        = 34, // Private
        SYMBOL_PROTECTED      = 35, // Protected
        SYMBOL_PUBLIC         = 36, // Public
        SYMBOL_REAL           = 37, // real
        SYMBOL_START          = 38, // Start
        SYMBOL_STATIC         = 39, // static
        SYMBOL_STRING         = 40, // string
        SYMBOL_TO             = 41, // to
        SYMBOL_VOID           = 42, // void
        SYMBOL_ARGS           = 43, // <args>
        SYMBOL_ASSIGN         = 44, // <assign>
        SYMBOL_CMINUSELEMET   = 45, // <c-elemet>
        SYMBOL_CLASS2         = 46, // <class>
        SYMBOL_CMINUSLIST     = 47, // <c-list>
        SYMBOL_CMINUSMETHOD   = 48, // <c-method>
        SYMBOL_CMINUSTYPE     = 49, // <c-type>
        SYMBOL_EXPR           = 50, // <expr>
        SYMBOL_FACTOR         = 51, // <factor>
        SYMBOL_FCALL          = 52, // <fcall>
        SYMBOL_FORMINUSSTMT   = 53, // <for-stmt>
        SYMBOL_FSTMT          = 54, // <fstmt>
        SYMBOL_FSTMTMINUSLIST = 55, // <fstmt-list>
        SYMBOL_FUNCMINUSSTMT  = 56, // <func-stmt>
        SYMBOL_IFMINUSSTMT    = 57, // <if-stmt>
        SYMBOL_INC            = 58, // <inc>
        SYMBOL_INITMINUSLIST  = 59, // <init-list>
        SYMBOL_LOGICMINUSEXPR = 60, // <logic-expr>
        SYMBOL_OP             = 61, // <op>
        SYMBOL_PROGRAM        = 62, // <program>
        SYMBOL_RETURN         = 63, // <return>
        SYMBOL_STMT           = 64, // <stmt>
        SYMBOL_STMTMINUSLIST  = 65, // <stmt-list>
        SYMBOL_TERM           = 66, // <term>
        SYMBOL_TYPES          = 67  // <types>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                             =  0, // <program> ::= Start <stmt-list> End
        RULE_OP_LT                                         =  1, // <op> ::= '<'
        RULE_OP_GT                                         =  2, // <op> ::= '>'
        RULE_OP_LTEQ                                       =  3, // <op> ::= '<='
        RULE_OP_GTEQ                                       =  4, // <op> ::= '>='
        RULE_OP_EQEQ                                       =  5, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                   =  6, // <op> ::= '!='
        RULE_TYPES_INT                                     =  7, // <types> ::= int
        RULE_TYPES_REAL                                    =  8, // <types> ::= real
        RULE_TYPES_STRING                                  =  9, // <types> ::= string
        RULE_TYPES_CHAR                                    = 10, // <types> ::= char
        RULE_INC_IDENTIFIER_PLUSPLUS                       = 11, // <inc> ::= Identifier '++'
        RULE_INC_IDENTIFIER_MINUSMINUS                     = 12, // <inc> ::= Identifier '--'
        RULE_STMT_SEMI                                     = 13, // <stmt> ::= <assign> ';'
        RULE_STMT_COLONCOLON                               = 14, // <stmt> ::= <if-stmt> '::'
        RULE_STMT_COLONCOLON2                              = 15, // <stmt> ::= <for-stmt> '::'
        RULE_STMT_SEMI2                                    = 16, // <stmt> ::= <inc> ';'
        RULE_STMT_SEMI3                                    = 17, // <stmt> ::= <types> <assign> ';'
        RULE_STMT_COLONCOLON3                              = 18, // <stmt> ::= <fstmt> '::'
        RULE_STMT_SEMI4                                    = 19, // <stmt> ::= <fcall> ';'
        RULE_STMT_COLONCOLON4                              = 20, // <stmt> ::= <class> '::'
        RULE_STMTLIST                                      = 21, // <stmt-list> ::= <stmt>
        RULE_STMTLIST2                                     = 22, // <stmt-list> ::= <stmt> <stmt-list>
        RULE_ASSIGN_IDENTIFIER_EQ                          = 23, // <assign> ::= Identifier '=' <expr>
        RULE_EXPR_PLUS                                     = 24, // <expr> ::= <term> '+' <expr>
        RULE_EXPR_MINUS                                    = 25, // <expr> ::= <term> '-' <expr>
        RULE_EXPR                                          = 26, // <expr> ::= <term>
        RULE_TERM_TIMES                                    = 27, // <term> ::= <factor> '*' <term>
        RULE_TERM_DIV                                      = 28, // <term> ::= <factor> '/' <term>
        RULE_TERM_PERCENT                                  = 29, // <term> ::= <factor> '%' <term>
        RULE_TERM                                          = 30, // <term> ::= <factor>
        RULE_FACTOR_LPAREN_RPAREN                          = 31, // <factor> ::= '(' <expr> ')'
        RULE_FACTOR_IDENTIFIER                             = 32, // <factor> ::= Identifier
        RULE_FACTOR_NUM                                    = 33, // <factor> ::= Num
        RULE_FACTOR_FLOAT                                  = 34, // <factor> ::= Float
        RULE_LOGICEXPR                                     = 35, // <logic-expr> ::= <expr> <op> <expr>
        RULE_IFSTMT_IF_COLON                               = 36, // <if-stmt> ::= if <logic-expr> ':' <stmt-list>
        RULE_IFSTMT_IF_COLON_ELSE                          = 37, // <if-stmt> ::= if <logic-expr> ':' <stmt-list> else <stmt-list>
        RULE_FORSTMT_FROM_TO_COLON                         = 38, // <for-stmt> ::= from <types> <assign> to <logic-expr> ':' <stmt-list>
        RULE_FSTMT_FUNCTION_IDENTIFIER_LPAREN_RPAREN_COLON = 39, // <fstmt> ::= function <return> Identifier '(' <init-list> ')' ':' <fstmt-list>
        RULE_RETURN                                        = 40, // <return> ::= <types>
        RULE_RETURN_VOID                                   = 41, // <return> ::= void
        RULE_INITLIST_IDENTIFIER_COMMA                     = 42, // <init-list> ::= <types> Identifier ',' <init-list>
        RULE_INITLIST_IDENTIFIER                           = 43, // <init-list> ::= <types> Identifier
        RULE_FSTMTLIST                                     = 44, // <fstmt-list> ::= <func-stmt>
        RULE_FSTMTLIST2                                    = 45, // <fstmt-list> ::= <func-stmt> <fstmt-list>
        RULE_FUNCSTMT_SEMI                                 = 46, // <func-stmt> ::= <assign> ';'
        RULE_FUNCSTMT_COLONCOLON                           = 47, // <func-stmt> ::= <if-stmt> '::'
        RULE_FUNCSTMT_COLONCOLON2                          = 48, // <func-stmt> ::= <for-stmt> '::'
        RULE_FUNCSTMT_SEMI2                                = 49, // <func-stmt> ::= <inc> ';'
        RULE_FUNCSTMT_SEMI3                                = 50, // <func-stmt> ::= <types> <assign> ';'
        RULE_FCALL_IDENTIFIER_LPAREN_RPAREN                = 51, // <fcall> ::= Identifier '(' <args> ')'
        RULE_ARGS_COMMA                                    = 52, // <args> ::= <factor> ',' <args>
        RULE_ARGS                                          = 53, // <args> ::= <factor>
        RULE_CLASS_CLASS_IDENTIFIER_COLON                  = 54, // <class> ::= Class Identifier ':' <c-list>
        RULE_CLIST                                         = 55, // <c-list> ::= <c-elemet> <c-list>
        RULE_CLIST2                                        = 56, // <c-list> ::= <c-method> <c-list>
        RULE_CLIST3                                        = 57, // <c-list> ::= <c-elemet>
        RULE_CLIST4                                        = 58, // <c-list> ::= <c-method>
        RULE_CELEMET_SEMI                                  = 59, // <c-elemet> ::= <c-type> <types> <assign> ';'
        RULE_CMETHOD_COLONCOLON                            = 60, // <c-method> ::= <c-type> <fstmt> '::'
        RULE_CTYPE_PUBLIC                                  = 61, // <c-type> ::= Public
        RULE_CTYPE_PRIVATE                                 = 62, // <c-type> ::= Private
        RULE_CTYPE_PROTECTED                               = 63, // <c-type> ::= Protected
        RULE_CTYPE_STATIC                                  = 64  // <c-type> ::= static
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLONCOLON :
                //'::'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //Class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //Float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FROM :
                //from
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //Num
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIVATE :
                //Private
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROTECTED :
                //Protected
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PUBLIC :
                //Public
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REAL :
                //real
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATIC :
                //static
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //to
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGS :
                //<args>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CMINUSELEMET :
                //<c-elemet>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS2 :
                //<class>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CMINUSLIST :
                //<c-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CMINUSMETHOD :
                //<c-method>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CMINUSTYPE :
                //<c-type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FCALL :
                //<fcall>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMINUSSTMT :
                //<for-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FSTMT :
                //<fstmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FSTMTMINUSLIST :
                //<fstmt-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCMINUSSTMT :
                //<func-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFMINUSSTMT :
                //<if-stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INC :
                //<inc>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INITMINUSLIST :
                //<init-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICMINUSEXPR :
                //<logic-expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //<return>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT :
                //<stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMTMINUSLIST :
                //<stmt-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPES :
                //<types>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <stmt-list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPES_INT :
                //<types> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPES_REAL :
                //<types> ::= real
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPES_STRING :
                //<types> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPES_CHAR :
                //<types> ::= char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INC_IDENTIFIER_PLUSPLUS :
                //<inc> ::= Identifier '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INC_IDENTIFIER_MINUSMINUS :
                //<inc> ::= Identifier '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_SEMI :
                //<stmt> ::= <assign> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_COLONCOLON :
                //<stmt> ::= <if-stmt> '::'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_COLONCOLON2 :
                //<stmt> ::= <for-stmt> '::'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_SEMI2 :
                //<stmt> ::= <inc> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_SEMI3 :
                //<stmt> ::= <types> <assign> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_COLONCOLON3 :
                //<stmt> ::= <fstmt> '::'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_SEMI4 :
                //<stmt> ::= <fcall> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_COLONCOLON4 :
                //<stmt> ::= <class> '::'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTLIST :
                //<stmt-list> ::= <stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMTLIST2 :
                //<stmt-list> ::= <stmt> <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_IDENTIFIER_EQ :
                //<assign> ::= Identifier '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <term> '+' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <term> '-' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <factor> '*' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <factor> '/' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <factor> '%' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_LPAREN_RPAREN :
                //<factor> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_IDENTIFIER :
                //<factor> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_NUM :
                //<factor> ::= Num
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_FLOAT :
                //<factor> ::= Float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICEXPR :
                //<logic-expr> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_COLON :
                //<if-stmt> ::= if <logic-expr> ':' <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTMT_IF_COLON_ELSE :
                //<if-stmt> ::= if <logic-expr> ':' <stmt-list> else <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORSTMT_FROM_TO_COLON :
                //<for-stmt> ::= from <types> <assign> to <logic-expr> ':' <stmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FSTMT_FUNCTION_IDENTIFIER_LPAREN_RPAREN_COLON :
                //<fstmt> ::= function <return> Identifier '(' <init-list> ')' ':' <fstmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN :
                //<return> ::= <types>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_VOID :
                //<return> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITLIST_IDENTIFIER_COMMA :
                //<init-list> ::= <types> Identifier ',' <init-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITLIST_IDENTIFIER :
                //<init-list> ::= <types> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FSTMTLIST :
                //<fstmt-list> ::= <func-stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FSTMTLIST2 :
                //<fstmt-list> ::= <func-stmt> <fstmt-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCSTMT_SEMI :
                //<func-stmt> ::= <assign> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCSTMT_COLONCOLON :
                //<func-stmt> ::= <if-stmt> '::'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCSTMT_COLONCOLON2 :
                //<func-stmt> ::= <for-stmt> '::'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCSTMT_SEMI2 :
                //<func-stmt> ::= <inc> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCSTMT_SEMI3 :
                //<func-stmt> ::= <types> <assign> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FCALL_IDENTIFIER_LPAREN_RPAREN :
                //<fcall> ::= Identifier '(' <args> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGS_COMMA :
                //<args> ::= <factor> ',' <args>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGS :
                //<args> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASS_CLASS_IDENTIFIER_COLON :
                //<class> ::= Class Identifier ':' <c-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLIST :
                //<c-list> ::= <c-elemet> <c-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLIST2 :
                //<c-list> ::= <c-method> <c-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLIST3 :
                //<c-list> ::= <c-elemet>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLIST4 :
                //<c-list> ::= <c-method>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CELEMET_SEMI :
                //<c-elemet> ::= <c-type> <types> <assign> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CMETHOD_COLONCOLON :
                //<c-method> ::= <c-type> <fstmt> '::'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CTYPE_PUBLIC :
                //<c-type> ::= Public
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CTYPE_PRIVATE :
                //<c-type> ::= Private
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CTYPE_PROTECTED :
                //<c-type> ::= Protected
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CTYPE_STATIC :
                //<c-type> ::= static
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
