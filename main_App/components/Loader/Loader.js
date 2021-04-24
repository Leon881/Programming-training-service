import React, {useState, useRef, useEffect} from "react";
import PropTypes from 'prop-types';
import './style.css';

export default function Loader() {
    return (<div id='loaderForm'><p>Данные еще загружаются. Пожалуйста, подождите</p> <div id='loader'/> </div>);
}

Loader.propTypes={
};