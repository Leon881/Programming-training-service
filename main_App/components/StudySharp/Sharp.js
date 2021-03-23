import React from 'react';
import PropTypes from 'prop-types';
import './style.css';
import ReturnButton from "../../containers/ReturnButton";

export default function StudySharp (){
    return (
        <div className='sharp-container'>
          <div className='menu'>
          <ReturnButton/>
            <div className='element' onClick={()=>{let bv= document.getElementById('test'); bv.classList.toggle('open-sub-menu') }}>
              <a  className='elem-title'>Начальный уровень</a>
              <div className='sub-menu' id='test'>
                <a>Тест 1</a>
                <a>Тест 2</a>
              </div>
              </div>

              <div className='element' onClick={()=>{let bv= document.getElementById('test1'); bv.classList.toggle('open-sub-menu') }}>
              <a className='elem-title'>Средний уровень</a>
              <div className='sub-menu' id='test1'>
                <a>Другой тест 1</a>
                <a>Другой тест 2</a>
              </div>
              </div>
          </div>
          <div className='working-field'>Рабочее поле</div>
        </div>
    )
}

StudySharp.propTypes={
};