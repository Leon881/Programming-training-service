import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link, useRouteMatch} from 'react-router-dom'
import Status from '../../constants/Status';
import Page from "../../constants/Page";
import Loader from "../../containers/Loader"
import './style.css';

export default function TestsNavigation ({onNavigateToPage, testsList}) {
  if (testsList.status === Status.loading) return <Loader fontColor='#fff'/>;
  const testForm = [];
  for (let el of testsList.tests){
      testForm.push (<Link className='test-ref' key={el.id} to={'/'}><div className='test-item'>
      <div className='image'  id={el.id} style={{'backgroundImage':`url(${el.image})`}}></div>
      <div className='test-inf' id={el.id} ><div id={el.id} className='test-title'>{el.title}</div>
      <div className='test-rating' id={el.id} >Ваш прогресс - {el.rating}</div></div>     
          </div></Link>)
  }


    return (
      <div className='main-tests-navigation'>
        <div className='nav'>
         <Link to={Page.testsMenu.route}> <div  onClick= {()=>{onNavigateToPage(Page.testsMenu.text)}}
          className='back-ref'>&#11013; Вернуться</div></Link></div> 
        <div className='tests-navigation'>
            <div className='tests-list'>
                {testForm}
            </div>
        </div>
      </div>
    )
}

TestsNavigation.propTypes = {
    onNavigateToPage: PropTypes.func.isRequired,
    testsList: PropTypes.object.isRequired
}
