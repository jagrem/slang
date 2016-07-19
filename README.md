slang
-----
A toy .NET language.

# Syntax #

Symbols are the atomic units from which the grammar of Slang is composed. A symbol is made up of one or more characters and is usually delimited by whitespace.

## Identifiers ##
Identifiers are user-defined symbols.

* Identifiers starting with a lower case letter can be used for names that are bound to _values_ such as functions, constants and variables.
* Identifiers starting with an upper case character are used for names that are bound to _types_.
* Identifiers can include upper and lower case characters, digits or one of the following connecting characters, '-', '_', or '+'.
* Identifiers can also optionally end in '?'

```
uppercase := 'A' | 'B' | 'C' | 'D' | 'E' | 'F' | 'G' | 'H' | 'I' | 'J' | 'K' | 'L' | 'M' | 'N' | 'O' | 'P' | 'Q' | 'R' | 'S' | 'T' | 'U' | 'V' | 'W' | 'X' | 'Y' | 'Z'

lowercase := 'a' | 'b' | 'c' | 'd' | 'e' | 'f'| 'g' | 'h' | 'i' | 'j' | 'k' | 'l' | 'm' | 'n' | 'o' | 'p' | 'q' | 'r' | 's' | 't' | 'u' | 'v' | 'w' | 'x' | 'y' | 'z'

numeric = '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9'

identifier-symbol := '-' | '_' | '+'

identifier-coda := { uppercase | lowercase | numeric | identifier-symbol } ['?']

value-identifier := lowercase [ identifier-coda ]

type-identifier := uppercase [ identifier-coda ]
```

## Operators ##
Operators are symbols that are defined as part of the language and represent core concepts in Slang. They cannot be redefined or overridden by users.

```
operator := '=' | '->' | '[' | ']'
```

### Bind or '=' ###
The character '=' is used to indicate a binding of an expression to an identifier.

```
bind := (value-identifier | type-identifier) '=' expression
```

### Produces or '->' ###
The character combination '->' is used to denote that the preceding term produces the following term.

### List or '[]' ###
The characters '[' and ']' denote the beginning and end of list definition respectively.

## Literals ##
A literal represents a constant value written in a standard format.

### Character ###
A character literal is a single character surrounded by inverted commas. It defines a unicode character value.

```
single-character := /* Any character except ' (U+0027), \ (U+005C), and new-line-character */

simple-escape-sequence := '\'' | '\"' | '\\' | '\0' | '\a' | '\b' | '\f' | '\n' | '\r' | '\t' | '\v'

character := single-character | simple-escape-sequence | hexadecimal-escape-sequence | unicode-escape-sequence

character-literal := ''' character '''
```
