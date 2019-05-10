declare module '*/mapgrammar.json' {
  interface MapGrammar {
    states: Statement[]
  }

  interface Statement {
    elem: string
    key: string | undefined
    sub_elem: string | undefined
    func: string | undefined
    skip_test: boolean | undefined

  }
}
