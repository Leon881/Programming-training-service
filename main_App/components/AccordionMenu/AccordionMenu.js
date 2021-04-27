import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom';
import Page from "../../constants/Page";
import './style.css';

export default function AccordionMenu ({ onNavigateToPage }){
    return (
      <div className='main-learning-container'>
        <div className='learning-container'>
          <div className='menu'>
            <Link className='back-ref' to ='/learning'>
          <div onClick= {()=>onNavigateToPage(Page.learningMenu)} className='button-back'>&lArr; Вернуться</div>
          </Link>
            <div className='element' onClick={()=>{document.getElementById('test').classList.toggle('open-sub-menu') }}>
              <a  className='elem-title'>Начальный уровень</a>
              <div className='sub-menu' id='test'>
                <a onClick={(event)=>event.stopPropagation()}>Тест 1</a>
                <a onClick={(event)=>event.stopPropagation()}>Тест 2</a>
              </div>
              </div>

              <div className='element' onClick={()=>{document.getElementById('test1').classList.toggle('open-sub-menu') }}>
              <a className='elem-title'>Средний уровень</a>
              <div className='sub-menu' id='test1'>
                <a onClick={(event)=>event.stopPropagation()}>Другой тест 1</a>
                <a onClick={(event)=>event.stopPropagation()}>Другой тест 2</a>
                <a onClick={(event)=>event.stopPropagation()}>Другой тест 2</a>
              </div>
              </div>
              <div className='element' onClick={()=>{document.getElementById('test2').classList.toggle('open-sub-menu') }}>
              <a className='elem-title'>Последний уровень</a>
              <div className='sub-menu' id='test2'>
                <a onClick={(event)=>event.stopPropagation()}>Другой тест 1</a>
                <a onClick={(event)=>event.stopPropagation()}>Другой тест 2</a>
              </div>
              </div>
          </div>
        </div>
        <div className='learning-content'>
        <div className='learning-text'>Проверка</div>
        </div>
        </div>
    )
}

AccordionMenu.propTypes={
    onNavigateToPage: PropTypes.func.isRequired,
  };