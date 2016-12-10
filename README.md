slang
-----
A toy .NET language.

# Syntax #

## Symbols ##
* A symbol can be a type or a variable or an operator

```
symbol := type-name | variable-name | operator
```

### Types ###
#### Type name ####
* Type names must start with an uppercase letter.
* A type name can contain a namespace.

```
simple-type-name := uppercase { alphanumeric | special-symbol }
type-name := { simple-type-name "." } simple-type-name
```

### Variables ###
#### Variable name ####
* Must start with a lowercase letter.

```
variable-name := lowercase { alphanumeric | special-symbol }
```

## Module ##
A module starts with a type name declaration. All bindings until the next module declaration or the end of the file are considered to be part of the same module.

### Module declaration ###
```
module-declaration := "module" type-name { binding }
```

## Bindings ##
* A binding maps a symbol to an expression.

```
binding := "let" symbol [type-declaration] "=" expression
```

## Type declaration ##
* A type declaration is used to express a type constraint.

```
type-declaration := "->" type-name { "->" type-name }
```

## Expressions ##
The simplest expressions are literals or function invocations
