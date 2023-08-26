import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import Menu from '../../components/menu/menu'
import Rodape from '../../components/rodape/rodape'
import './cadastroCombos.css'

class CadastroCombos extends Component{
    render(){
        return(
            <>
                <Menu/>
                <Rodape/>
            </>
        )
    }
}

export default CadastroCombos