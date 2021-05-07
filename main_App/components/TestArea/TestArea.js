import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import './style.css';
import Status from '../../constants/Status';
import Page from "../../constants/Page";
import Loader from "../../containers/Loader";
import testQuestions from "../../forTests/testQuestions";

export default function TestArea ({onNavigateToPage, page}){
    //if (testsList.status === Status.loading) return <Loader fontColor='#fff'/>;
    const navigate = (indicate)=>{
        let route;
        switch (page.split(' ')[0]){
       case Page.testsSharp.text:
           route= Page.testsSharp;
           break;
       case Page.testsJS.text:
           route=Page.testsJS;
           break;
       case Page.testsSQL.text:
            route=Page.testsSQL;
            break;
       default:
            break;
        }
        return indicate ? route.route : route.text
    }

    const test=[];
    for (let el of testQuestions){
        test.push (<div key={el.id} className='test'>
            <div className='test-data'><div className='test-question'>{el.question}</div>
            <div className='test-answer'>{el.type===1 ? <div className='test-options'>
            <label><p><input className='input-button' name={el.id} type='radio' value={el.options[0]}/>{el.options[0]}</p></label>
            <label><p><input className='input-button' name={el.id} type='radio' value={el.options[1]}/>{el.options[1]}</p></label>
            <label><p><input className='input-button' name={el.id} type='radio' value={el.options[2]}/>{el.options[2]}</p></label>
            <label><p><input className='input-button' name={el.id} type='radio' value={el.options[3]}/>{el.options[3]}</p></label>
            </div> : <div className='test-input'><input id={el.id} placeholder='Введите ваш ответ'/></div> }</div>
            </div></div>)
    }

    return (
        <div className='main-test-area'>
        <div className='nav'>
         <Link to={navigate(true)}> <div  onClick= {()=>{onNavigateToPage(navigate(false))}}
          className='back-ref'>&#11013; Вернуться</div></Link></div> 
          <div className='test-menu'>
              <div className='test-list'>
                  {test}
                  <div className='end-button'>Завершить</div>
              </div>
          </div>
        </div>
    )
}

TestArea.propTypes={
    onNavigateToPage: PropTypes.func.isRequired,
    page: PropTypes.string.isRequired
};