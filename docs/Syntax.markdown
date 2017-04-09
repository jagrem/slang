# Syntax #

## Operators ##
* Operators are infixed by default, i.e. binary operators are written between their arguments rather than in front of them like a normal function application.
* An operator can be used like a function and precede its arguments by prefixing it with ".".

```
operator := + | - | / | % | *
infix-operator := operator
prefix-operator := "." operator
```

## Names ##
### Namespace names ###
* Start with an upper case letter.
* Can contain any combination alpha-numeric characters except for the leading letter.

```
namespace-name := uppercase { alphanumeric }
```

### Module names ###
* Start with an upper case letter.
* Can contain any combination alpha-numeric characters except for the leading letter.

```
module-name := uppercase { alphanumeric }
```

### Type names ###
* Start with an upper case letter.
* Can contain any combination alpha-numeric characters except for the leading letter.

```
type-name := uppercase { alphanumeric }
```

### Value names ###
* Start with a lower case letter.
* Can contain any combination alpha-numeric characters except for the leading letter.

```
value-name := lowercase { alphanumeric }
```

## Namespaces ##
* Contain only valid namespace names separated by ".".

```
namespace := namespace-name  { "." namespace-name }
namespace-prefix := namespace "."
namespace-declaration := "namespace" namespace
```

## Modules ##
* Can be prefixed with a namespace.
* Contain only bindings.

```
module-declaration := "module" [namespace-prefix] module-name { module-binding }
module-binding := value-name [type-annotation] "=" expression
```

Examples
```
module Com.Slang.Shared

    addOne int -> int
        : x = x + 1
        : 1 = 0
```

## Types ##
* Declarations must start with the word 'type' and define a binding to a valid type name.
* Annotations are suffixed to values.

```
type-declaration := "type" type-name { type-binding }
type-annotation := "->" type-name { "->" type-name }
```

## Expressions ##

```
expression := literal | value-name | "(" function-application ")"
```

### Literal ###
```
literal := integer-literal | string-literal
```

#### Integer literal ####
```
integer-literal := (decimal-integer-literal | hexadecimal-integer-literal) [integer-specifier]

numeric := 0..9
non-zero-numeric := 1..9

decimal-integer-literal := numeric | non-zero-numeric { numeric }

hexadecimal-alpha := a..f | A..F
hexadecimal-integer-literal := "0x" { numeric | hexadecimal-alpha }

integer-specifier := "u" | "l" | "ul" | "lu"
```

#### String literal ####
```
string-literal := """ any-unicode-character-except-quote """
```

### Function application ###
```
function-application := value-name { expression }
```
