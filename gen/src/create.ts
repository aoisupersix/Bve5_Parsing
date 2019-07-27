import * as fs from 'fs'
import * as yaml from 'js-yaml'

import { IMapDefinition } from './definition/iMapDefinition';
import { convert } from './convert';
import { render } from './render';

const file = fs.readFileSync(`${__dirname}/mapgrammar.yaml`, 'utf8')
const definition: IMapDefinition[] = yaml.safeLoad(file)
const statements = convert(definition)

const astVisitor = render(fs.readFileSync(`${__dirname}/../template/map_grammar_ast_visitor.mst`, 'utf8'), statements)
console.log(astVisitor)
