import React, { Component } from 'react'
import { MDBInput } from 'mdbreact'
import { Link } from 'react-router-dom'
import './login.css'

class login extends Component{
  render(){
    return(
      <>
        <body className="bodyLogin_lgn">
          <section className="rowLogin_lgn">
            <div className="logoPrincipal_lgn">
              <img src={require('./assets/img/logo-large.svg')} alt=""/>
            </div>
            <section className="secaoLogin_lgn">
              <div className="tituloLogin_lgn">
                <h1>Bem vindo ao sistema da Chosen</h1>
                <hr/>
              </div>
              <div className="formsLogin_lgn">
                <form className="formularioLogin_lgn">
                    <MDBInput label="Qual é o seu nome?" type="text" />
                    <MDBInput label="Qual é a sua senha?" type="password" />
                    <button type="submit"><Link to={'/home'}>Entrar</Link></button>
                </form>
              </div>
            </section>
          </section>
        </body>
      </>
    )
  }
}

export default login
