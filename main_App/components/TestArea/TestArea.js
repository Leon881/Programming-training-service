import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import './style.css';
import Status from '../../constants/Status';
import Page from "../../constants/Page";
import Loader from "../../containers/Loader";

export default function TestArea ({onNavigateToPage, page, test}){
    const checkTest = async (event)=>{
        event.preventDefault();
        let newRating=0;
        for (let el of test.test.questions){
            if (el.type === 1){
                let selectedVar=document.querySelector(`input[name='${(el.id)}']:checked`).value;
                if (el.correct === selectedVar){
                 document.getElementById(`result ${el.id}`).style.backgroundImage='url(/src/img/check.png)';
                newRating++;}
                else{
                document.getElementById(`result ${el.id}`).style.backgroundImage='url(/src/img/cross.png)';
                 }
                 Array.from(document.querySelectorAll(`input[name='${(el.id)}']`)).map(item=> {
                    item.value === el.correct ? item.parentElement.style.color='LightGreen': item.parentElement.style.color='LightCoral'});
            }
            else {
                document.getElementById(`${el.id}`).disabled=true;
                let inputVar= document.getElementById(`${el.id}`);
                if(el.correct===String(inputVar.value)) { 
                    document.getElementById(`result ${el.id}`).style.backgroundImage='url(/src/img/check.png)';
                    newRating++;
                }
                else{ 
                document.getElementById(`result ${el.id}`).style.backgroundImage='url(/src/img/cross.png)';
                inputVar.style.color='red';
                inputVar.value=el.correct;
                }
            }
        }
        newRating= (newRating / test.test.questions.length).toFixed(2); ;
        console.log(newRating);
          /*
        await fetch(src, {
            method: "PUT",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
              //
            })
        });
        */

    };
    if (test.status === Status.loading) return <Loader fontColor='#fff'/>;
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

    const testForm=[];
    for (let el of test.test.questions){
        testForm.push (<div key={el.id} id={`question ${el.id}`} className='test'>
            <div className='test-data'><div className='test-question'>{el.question}</div>
            <div className='test-answer'>{el.type===1 ? <div className='test-options'>
            <label><p><input className='input-button' name={el.id} type='radio' value={el.options[0]} required/>{el.options[0]}</p></label>
            <label><p ><input className='input-button' name={el.id} type='radio' value={el.options[1]}/>{el.options[1]}</p></label>
            <label><p><input className='input-button' name={el.id} type='radio' value={el.options[2]}/>{el.options[2]}</p></label>
            <label><p><input className='input-button' name={el.id} type='radio' value={el.options[3]}/>{el.options[3]}</p></label>
            </div> : <div className='test-input'><input id={el.id} placeholder='Введите ваш ответ' required /></div> }</div>
            </div><div id={`result ${el.id}`} className='result'/></div>)
    }

    return (
        <div className='main-test-area'>
        <div className='nav'>
         <Link to={navigate(true)}> <div  onClick= {()=>{onNavigateToPage(navigate(false))}}
          className='back-ref'>&#11013; Вернуться</div></Link></div> 
          <div className='test-menu'>
              <form onSubmit={checkTest} className='test-list'>
                  {testForm}
                  <input type='submit' className='end-button' value='Завершить'/>
              </form>
          </div>
        </div>
    )
}

TestArea.propTypes={
    onNavigateToPage: PropTypes.func.isRequired,
    page: PropTypes.string.isRequired,
    test: PropTypes.object.isRequired
};