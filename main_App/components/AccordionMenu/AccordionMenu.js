import React from 'react';
import PropTypes, { object } from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom';
import Page from "../../constants/Page";
import testAccordionMenu from "../../forTests/index"
import './style.css';

export default function AccordionMenu ({ onNavigateToPage }){
  const accordionMenu = [];
  const subMenu=[]
  for (let el of testAccordionMenu){
    accordionMenu.push(<div key={el.id} className='element' onClick={()=>{document.getElementById(el.sectionName).classList.toggle('open-sub-menu') }}>
    <a  className='elem-title'>{el.sectionName}</a>
    <div className='sub-menu' id={el.sectionName}>
      {el.articles.map(function (obj,i){
        return <a key={obj.id} onClick={(event)=>event.stopPropagation()}>{obj.name}</a>
      }) }
    </div>
    </div>) 
  }
    return (
      <div className='main-learning-container'>
        <div className='learning-container'>
          <div className='menu'>
            <Link className='back-ref' to ='/learning'>
          <div onClick= {()=>onNavigateToPage(Page.learningMenu)} className='button-back'>&lArr; Вернуться</div>
          </Link>
            {accordionMenu}
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